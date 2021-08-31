using ReaderStackExchangeXml.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Votes
{
    public class VotesRepository : BaseInsertRepository<Vote>
    {
        public VotesRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public override string GetInsertSql()=> @"insert into votes (Id, user_id,post_id,vote_type_id,bounty_amount,creation_date)
values(@Id, @UserId,@PostId,@VoteTypeId,@BountyAmount,@CreationDate) ON CONFLICT (Id) DO NOTHING;";
    }
}
