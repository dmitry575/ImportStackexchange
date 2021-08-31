using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
    public class ImportPostLinks : BaseImport<PostLink>
    {
        public override TypeFile TypeFile => TypeFile.PostLinks;

        public ImportPostLinks(IInsertRepository<PostLink> t) : base(t)
        {
        }
    }
}