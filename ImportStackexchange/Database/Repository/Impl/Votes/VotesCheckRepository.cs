using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Votes
{
    public class VotesCheckRepository : BaseCheckRepository<VotesTableInfo>
    {
        public VotesCheckRepository(VotesTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
