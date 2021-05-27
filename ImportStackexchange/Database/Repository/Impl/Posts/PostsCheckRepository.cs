using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Posts
{
    public class PostsCheckRepository : BaseCheckRepository<PostsTableInfo>
    {
        public PostsCheckRepository(PostsTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
