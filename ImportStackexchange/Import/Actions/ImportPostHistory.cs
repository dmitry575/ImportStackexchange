using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
    public class ImportPostHistory : BaseImport<PostHistory>
    {
        public override TypeFile TypeFile => TypeFile.PostHistory;

        public ImportPostHistory(IInsertRepository<PostHistory> t) : base(t)
        {
        }
    }
}