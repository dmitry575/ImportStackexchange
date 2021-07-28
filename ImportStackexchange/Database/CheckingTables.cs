using ImportStackexchange.Database.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImportStackexchange.Database
{
    /// <summary>
    /// Checking schema to database
    /// </summary>
    public class CheckingTables
    {
        private readonly IEnumerable<ICheckRepository> _chekers;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CheckingTables));

        public CheckingTables(IEnumerable<ICheckRepository> chekers)
        {
            _chekers = chekers;
        }

        public async Task CheckerCreate()
        {
            if (_chekers == null)
                return;

            foreach (var checker in _chekers)
            {
                try
                {
                    Logger.Info($"check begin: {checker.GetType().Name}");
                    if (!await checker.TableExistsAsync())
                    {
                        if (await checker.CreateTableAsync())
                        {
                            Logger.Info($"check created table {nameof(checker)}");
                        }
                    }

                    Logger.Info($"check end: {checker.GetType().Name}");
                }
                catch (Exception e)
                {
                    Logger.Error($"check or create {nameof(checker)} failed. {e}");
                }
            }
        }
    }
}