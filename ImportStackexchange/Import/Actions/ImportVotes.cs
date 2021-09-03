using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
   public class ImportVotes : BaseImport<Vote>
    {
        public override TypeFile TypeFile => TypeFile.Votes;

        public ImportVotes(IInsertRepository<Vote> repo, IReaderStackExchangeXml<Vote> reader) : base(repo, reader)
        {
        }
    }
}
