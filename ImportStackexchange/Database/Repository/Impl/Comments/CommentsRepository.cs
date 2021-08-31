using ReaderStackExchangeXml.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Comments
{
    public class CommentsRepository : BaseInsertRepository<Comment>
    {
        private const string InsertSql = @"insert into comments (id, post_id,user_id,score,content_license,text,creation_date)
values(@Id, @PostId,@UserId,@Score,@ContentLicense,@Text, @CreationDate) ON CONFLICT (Id) DO NOTHING;";

        public CommentsRepository(IDbConnection dbConnection) : base(dbConnection) { }

        public override string GetInsertSql() => InsertSql;
    }
}
