using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
   public class ImportVotes : BaseImport<Vote>
    {
        public override TypeFile TypeFile => TypeFile.Votes;

        public ImportVotes(IInsertRepository<Vote> t) : base(t)
        {
        }
    }
}
