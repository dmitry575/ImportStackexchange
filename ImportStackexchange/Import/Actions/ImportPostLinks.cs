using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
    public class ImportPostLinks : BaseImport<PostLink>
    {
        public override TypeFile TypeFile => TypeFile.PostLinks;

        public ImportPostLinks(IInsertRepository<PostLink> repo, IReaderStackExchangeXml<PostLink> reader) : base(repo, reader)
        {
        }
    }
}