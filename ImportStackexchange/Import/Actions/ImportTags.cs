using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
    /// <summary>
    /// Import tags to database
    /// </summary>
    public class ImportTags : BaseImport<Tag>
    {
        public override TypeFile TypeFile => TypeFile.Tags;
     
        public ImportTags(IInsertRepository<Tag> repo, IReaderStackExchangeXml<Tag> reader) : base(repo, reader)
        {
        }
    }
}
