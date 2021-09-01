using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.PostHistories
{
    public class PostHistoryCheckRepository : BaseCheckRepository<PostHistoryTableInfo>
    {
        public PostHistoryCheckRepository(PostHistoryTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
