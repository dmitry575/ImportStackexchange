using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.PostHistory
{
    public class PostHistoryCheckRepository : BaseCheckRepository<PostHistoryTableInfo>
    {
        public PostHistoryCheckRepository(PostHistoryTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
