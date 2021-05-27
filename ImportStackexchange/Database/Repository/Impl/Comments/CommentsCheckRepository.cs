using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Comments
{
    public class CommentsCheckRepository : BaseCheckRepository<CommentsTableInfo>
    {
        public CommentsCheckRepository(CommentsTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
