using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
    class ImportBadges : BaseImport<Badge>
    {
        public override TypeFile TypeFile => TypeFile.Badges;

        public ImportBadges(IInsertRepository<Badge> t) : base(t)
        {
        }
    }
}