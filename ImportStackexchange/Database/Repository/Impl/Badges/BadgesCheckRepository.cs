using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Badges
{
    public class BadgesCheckRepository : BaseCheckRepository<BadgesTableInfo>
    {
        public BadgesCheckRepository(BadgesTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
