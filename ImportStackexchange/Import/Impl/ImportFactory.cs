using ImportStackexchange.Enums;
using System.Collections.Generic;

namespace ImportStackexchange.Import.Impl
{
    /// <summary>
    /// Creating import factor
    /// </summary>
    public class ImportFactory : IImportFactory
    {
        private readonly IEnumerable<IImportFile> _importerFiles;

        public ImportFactory(IEnumerable<IImportFile> importerFiles) => _importerFiles = importerFiles;

        /// <summary>
        /// Create importer by type of file
        /// </summary>
        /// <param name="typeFile">Type of file witch need to import</param>
        public IImportFile Create(TypeFile typeFile)
        {
            foreach (var t in _importerFiles)
            {
                if (t.TypeFile == typeFile)
                {
                    return t;
                }
            }

            return null;
        }
    }
}
