using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
    public class ImportUsers : BaseImport<User>
    {
        public override TypeFile TypeFile => TypeFile.Users;

        public ImportUsers(IInsertRepository<User> repo, IReaderStackExchangeXml<User> reader) : base(repo, reader)
        {
        }
    }
}
