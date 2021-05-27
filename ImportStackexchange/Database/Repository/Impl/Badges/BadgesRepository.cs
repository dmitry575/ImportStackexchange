using ImportStackexchange.Database.Models;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Badges
{
    public class BadgesRepository : BaseInsertRepository<Badge>
    {
        private const string InsertSql = @"insert into badges (Id, user_id,name,date,class,tag_based)
values(@Id, @UserId,@Name,@Date,@Class,@TagBased) ON CONFLICT (Id) DO NOTHING;";

        public BadgesRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


        public override string GetInsertSql() => InsertSql;
    }
}
