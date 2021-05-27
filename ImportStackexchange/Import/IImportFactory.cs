using ImportStackexchange.Enums;

namespace ImportStackexchange.Import
{
    public interface IImportFactory
    {
        /// <summary>
        /// Creating file import by type
        /// </summary>
        /// <param name="typeFile">Type of file</param>
        IImportFile Create(TypeFile typeFile);
    }
}
