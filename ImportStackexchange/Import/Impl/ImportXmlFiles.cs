using ImportStackexchange.Common;
using ImportStackexchange.Config;
using ImportStackexchange.Enums;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ImportStackexchange.Import.Impl
{
    /// <summary>
    /// Import xml files
    /// </summary>
    public class ImportXmlFiles
    {
        /// <summary>
        /// Configuration
        /// </summary>
        private readonly ConfigOptions _config;

        /// <summary>
        /// List of mapping type and file name
        /// </summary>
        private readonly Dictionary<TypeFile, string> _files;

        /// <summary>
        /// Factory for creating importing
        /// </summary>
        private readonly IImportFactory _importFactory;

        /// <summary>
        /// Queue import data from xml to db
        /// </summary>
        private readonly TaskQueue _taskQueue = new(5);

        private static readonly ILog _logger = LogManager.GetLogger(typeof(ImportXmlFiles));

        public ImportXmlFiles(ConfigOptions config, IImportFactory importFactory)
        {
            _config = config;
            _importFactory = importFactory;

            _files = new Dictionary<TypeFile, string>
            {
                {TypeFile.Badges, "badges.xml"},
                {TypeFile.Comments, "comments.xml"},
                {TypeFile.PostHistory, "posthistory.xml"},
                {TypeFile.PostLinks, "postlinks.xml"},
                {TypeFile.Posts, "posts.xml"},
                {TypeFile.Tags, "tags.xml"},
                {TypeFile.Users, "users.xml"},
                {TypeFile.Votes, "votes.xml"},
            };
        }

        /// <summary>
        /// Starting work
        /// </summary>
        public async Task WorkAsync()
        {
            _logger.Info("Starting parsing xml files...");
            var tasks = new List<Task>();

            List<TypeFile> typeFiles = GetTypeFiles(_config.FileNames);

            bool isAll = typeFiles.Count == 0 || typeFiles.Contains(TypeFile.All);

            foreach (var file in _files)
            {
                if (isAll || typeFiles.Contains(file.Key))
                {
                    _logger.Info($"starting work: {file.Key}");
                    var import = _importFactory.Create(file.Key);
                    if (import == null)
                    {
                        _logger.Error($"not found parser for file: {file.Value}");
                        continue;
                    }

                    var xmlFile = Path.Combine(_config.WorkPath, file.Value);
                    try
                    {
                        var t = _taskQueue.Enqueue(async () => await import.ImportToDbAsync(xmlFile));
                        tasks.Add(t);
                        _logger.Info($"added to queue {xmlFile}");
                    }
                    catch (Exception e)
                    {
                        _logger.Error($"import add to list execute: file {xmlFile}, key: {file.Key}, {e}");
                    }
                }
                else
                {
                    _logger.Info($"ingnored {file.Key}");
                }
            }

            // await for the rest of tasks to complete
            await Task.WhenAll(tasks);

            _logger.Info("parsing xml files finished");
        }

        /// <summary>
        /// Parsing all types from string
        /// </summary>
        /// <param name="configFileNames">Config file name</param>
        private List<TypeFile> GetTypeFiles(IEnumerable<string> configFileNames)
        {
            var result = new List<TypeFile>();
            foreach (var fileName in configFileNames)
            {
                try
                {
                    var type = (TypeFile) Enum.Parse(typeof(TypeFile), fileName, true);
                    result.Add(type);
                }
                catch (Exception)
                {
                    _logger.Error($"invalid type of {fileName}");
                }
            }

            if (result.Count == 0)
            {
                result.Add(TypeFile.All);
            }

            return result;
        }
    }
}