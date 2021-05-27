using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
    public class ImportUsers : BaseImport<User>
    {
        public override TypeFile TypeFile => TypeFile.Users;

        public ImportUsers(IInsertRepository<User> t) : base(t)
        {
        }
    }
}
