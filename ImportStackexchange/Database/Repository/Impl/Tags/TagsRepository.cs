using ReaderStackExchangeXml.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Tags
{
    public class TagsRepository : BaseInsertRepository<Tag>
    {
        public TagsRepository(IDbConnection connection) : base(connection)
        {
        }
        public override string GetInsertSql() => @"insert into tags (Id, tag_name,excerpt_post_id,wiki_post_id)
values(@Id, @TagName,@ExcerptPostId,@WikiPostId) ON CONFLICT (Id) DO NOTHING;";

    }
}
