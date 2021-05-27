using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.PostLinks
{
    public class PostLinksCheckRepository : BaseCheckRepository<PostLinksTableInfo>
    {
        public PostLinksCheckRepository(PostLinksTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
