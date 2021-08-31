using CommandLine;
using CommandLine.Text;
using ImportStackexchange.Config;
using ImportStackexchange.Database;
using ImportStackexchange.Import.Impl;
using ImportStackexchange.Ioc;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;
using ReaderStackExchangeXml.Ioc;

[assembly: XmlConfigurator(Watch = true, ConfigFile = "log4net.config")]

namespace ImportStackexchange
{
    class Program
    {
        /// <summary>
        /// Configuration data from appsettings.json
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        private static ServiceProvider ServiceProvider;

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Starting import data from XMLs to database StackExchange");
            Console.WriteLine($"Version: {Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine("");

            AppDomain.CurrentDomain.ProcessExit += ProcessExit;

            var basePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
            var appsettingsPath = Path.Join(basePath, "appsettings.json");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            try
            {
                Configuration = new ConfigurationBuilder().AddJsonFile(appsettingsPath, false).Build();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Error($"parsing configuration failed: {e}");
                return;
            }

            var serviceCollection = new ServiceCollection();
            try
            {
                serviceCollection
                    .ConfigureContainer(Configuration)
                    .AddReaderStackXml();
            }
            catch (Exception e)
            {
                Logger.Error($"error configuration: {e}");
                return;
            }


            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Console.CancelKeyPress += CancelHandler;

            Logger.InfoFormat("Initialisation finished");
            var textHelp = HelpText.AutoBuild(Parser.Default.ParseArguments<ConfigOptions>(args), _ => _, _ => _);

            if (args.Length > 0 && args[0].Equals("help", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine(textHelp.ToString());
                return;
            }

            var options = new ConfigOptions();

            var resultOptions = Parser.Default.ParseArguments<ConfigOptions>(args)
                .WithParsed(x => options = x);

            var er = resultOptions as NotParsed<ConfigOptions>;

            if (er != null && er.Errors.Count() > 0)
            {
                Logger.InfoFormat("Invalid arguments");
                return;
            }

            Logger.InfoFormat(textHelp.ToString());

            // add parametrs
            serviceCollection.AddSingleton(opt => options);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            // first step checking tables
            if (options.CheckExists)
            {
                try
                {
                    var checkTablesWorker = ServiceProvider.GetService<CheckingTables>();

                    if (checkTablesWorker != null) await checkTablesWorker.CheckerCreate();

                }
                catch (NpgsqlException e)
                {
                    Logger.Error($"error working with database: {e.Message}");
                }
            }

            var parsing = ServiceProvider.GetService<ImportXmlFiles>();
            if (parsing != null) await parsing.WorkAsync();

            Console.WriteLine("Work finished...");
        }

        /// <summary>
        /// Event of exit application
        /// </summary>
        private static void ProcessExit(object sender, EventArgs e)
        {
            Logger.InfoFormat("Application exit");
            var cancellationTokenSource = ServiceProvider.GetService<CancellationTokenSource>();
            cancellationTokenSource?.Cancel();
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error($"UnhandledException: {e.ExceptionObject}");
        }

        private static void CancelHandler(object sender, ConsoleCancelEventArgs e)
        {
            var cancellationTokenSource = ServiceProvider.GetService<CancellationTokenSource>();
            cancellationTokenSource?.Cancel();
            Logger.InfoFormat("Cancelation token turned on");
        }
    }
}