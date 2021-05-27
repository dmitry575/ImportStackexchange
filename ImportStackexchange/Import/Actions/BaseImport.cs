﻿using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ImportStackexchange.Extentions;
using ImportStackexchange.Import.Impl;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImportStackexchange.Import.Actions
{
    /// <summary>
    /// Base class of importing data
    /// </summary>
    public abstract class BaseImport<T> : IImportFile where T : class
    {

        private static readonly ILog _logger = LogManager.GetLogger(typeof(ImportTags));

        private readonly IInsertRepository<T> _insertRepository;

        public abstract TypeFile TypeFile { get; }

        public int BulkCount => 1000;

        public BaseImport(IInsertRepository<T> t)
        {
            _insertRepository = t;
        }

        public async Task ImportToDbAsync(string fileName)
        {
            if (!File.Exists(fileName))
            {
                _logger.Error($"File not exists: {fileName}");
                return;
            }
            var count = 0;

            try
            {
                var parsingXml = new ParsingXml(fileName);

                var list = new List<T>();
                await foreach (var reader in parsingXml.ParseAsync())
                {
                    // DeSerialize
                    var data = reader.XmlDeserialize<T>();
                    if (list.Count >= BulkCount)
                    {
                        try
                        {
                            _insertRepository.InsertBulk(list);
                            _logger.Info($"items {typeof(T).Name} {list.Count} added to db");
                            count += list.Count;
                        }
                        catch (Exception e)
                        {
                            _logger.Error($"adding {typeof(T).Name} {list.Count} to db failed: {e}");
                        }
                        finally
                        {
                            list.Clear();
                        }
                    }
                    list.Add(data);
                }

                if (list.Count > 0)
                {
                    _insertRepository.InsertBulk(list);
                    count += list.Count;
                }
            }
            catch (Exception e)
            {
                _logger.Error($"import file failed: {fileName}, {e}");
            }

            _logger.Info($"{typeof(T).Name} {count} items added to database");
        }
    }
}
