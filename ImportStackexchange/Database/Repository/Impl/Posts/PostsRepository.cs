using ReaderStackExchangeXml.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Posts
{
    public class PostsRepository : BaseInsertRepository<Post>
    {
        public PostsRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public override string GetInsertSql() => @"insert into posts (id, owner_user_id,last_editor_user_id,post_type_id,accepted_answer_id,score,parent_id,view_count,answer_count,comment_count,title,tags,content_license,body,favorite_count,creation_date,community_owned_date,closed_date,last_edit_date,last_activity_date)
values(@Id, @OwnerUserId, @LastEditorUserId, @PostTypeId, @AcceptedAnswerId,@Score,@ParentId,@ViewCount,@AnswerCount,@CommentCount,@Title,@Tags,@ContentLicense,@Body,@FavoriteCount,@CreationDate,@CommunityOwnedDate,@ClosedDate,@LastEditDate,@LastActivityDate) ON CONFLICT(Id) DO NOTHING;";
    }
}
