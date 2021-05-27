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
        private readonly TaskQueue _taskQueue = new TaskQueue(5);

        private static readonly ILog _logger = LogManager.GetLogger(typeof(ImportXmlFiles));

        public ImportXmlFiles(ConfigOptions config, IImportFactory importFactory)
        {
            _config = config;
            _importFactory = importFactory;

            _files = new Dictionary<TypeFile, string> {
                { TypeFile.Badges,"badges.xml"},
                { TypeFile.Comments,"comments.xml"},
                { TypeFile.PostHistory,"posthistory.xml"},
                { TypeFile.PostLinks,"postlinks.xml"},
                { TypeFile.Posts,"posts.xml"},
                { TypeFile.Tags,"tags.xml"},
                { TypeFile.Users,"users.xml"},
                { TypeFile.Votes,"votes.xml"},
            };
        }

        /// <summary>
        /// Starting work
        /// </summary>
        public async Task WorkAsync()
        {
            var tasks = new List<Task>();


            foreach (var file in _files)
            {
                if (_config.FileName == TypeFile.All || _config.FileName == file.Key)
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

            }
            // await for the rest of tasks to complete
            await Task.WhenAll(tasks);

            return;
        }
    }
}
