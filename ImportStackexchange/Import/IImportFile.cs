using ImportStackexchange.Enums;
using System.Threading.Tasks;

namespace ImportStackexchange.Import
{
    /// <summary>
    /// Import one file to Database
    /// </summary>
    public interface IImportFile
    {
        /// <summary>
        /// Parsing file and add to Database
        /// </summary>
        /// <param name="fileName"></param>
        Task ImportToDbAsync(string fileName);

        /// <summary>
        /// Type of file can importing
        /// </summary>
        TypeFile TypeFile { get; }

        /// <summary>
        /// Count of Bulk
        /// </summary>
        int BulkCount { get; }
    }
}
