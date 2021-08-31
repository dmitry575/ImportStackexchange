using ReaderStackExchangeXml.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Users
{
    public class UsersRepository : BaseInsertRepository<User>
    {
        public UsersRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public override string GetInsertSql() => @"insert into users (Id, account_id,reputation,views,down_votes,up_votes,display_name,location,profile_image_url,website_url,about_me,creation_date,last_access_date)
values(@Id, @AccountId,@Reputation,@Views,@DownVotes,@UpVotes,@DisplayName,@Location,@ProfileImageUrl,@WebsiteUrl,@AboutMe,@CreationDate,@LastAccessDate) ON CONFLICT (Id) DO NOTHING;";

    }
}
