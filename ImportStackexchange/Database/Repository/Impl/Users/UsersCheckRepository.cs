using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Users
{
    public class UsersCheckRepository : BaseCheckRepository<UsersTableInfo>
    {
        public UsersCheckRepository(UsersTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
