using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
    public class ImportPostHistory : BaseImport<PostHistory>
    {
        public override TypeFile TypeFile => TypeFile.PostHistory;

        public ImportPostHistory(IInsertRepository<PostHistory> repo, IReaderStackExchangeXml<PostHistory> reader) : base(repo, reader)
        {
        }
    }
}