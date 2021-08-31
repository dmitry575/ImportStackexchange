using ReaderStackExchangeXml.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.PostHistorys
{
    public class PostHistoryRepository : BaseInsertRepository<PostHistory>
    {
        private const string InsertSql = @"insert into post_history (id, post_id,user_id,post_history_type_id,content_license,revision_guid,text,comment,creation_date)
values(@Id, @PostId,@UserId,@PostHistoryTypeId,@ContentLicense,@RevisionGUID,@Text,@Comment,@CreationDate) ON CONFLICT (Id) DO NOTHING;";
        public PostHistoryRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public override string GetInsertSql() => InsertSql;
    }
}
