using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
    class ImportBadges : BaseImport<Badge>
    {
        public override TypeFile TypeFile => TypeFile.Badges;

        public ImportBadges(IInsertRepository<Badge> repo, IReaderStackExchangeXml<Badge> reader) : base(repo, reader)
        {
        }
    }
}