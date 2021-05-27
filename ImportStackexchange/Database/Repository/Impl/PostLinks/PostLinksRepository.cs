using ImportStackexchange.Database.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.PostLinks
{
    public class PostLinksRepository : BaseInsertRepository<PostLink>
    {
        public PostLinksRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public override string GetInsertSql() => @"insert into post_links (id, related_post_id,post_id,link_type_id,creation_date)
values(@Id, @RelatedPostId, @PostId, @LinkTypeId, @CreationDate) ON CONFLICT(Id) DO NOTHING;";
    }
}
