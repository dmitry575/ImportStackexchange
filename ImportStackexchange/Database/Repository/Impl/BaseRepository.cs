using System.Data;

namespace ImportStackexchange.Database.Repository
{
    /// <summary>
    /// Base class of repositories
    /// </summary>
    public class BaseRepository
    {
        protected IDbConnection _connection;
        public BaseRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
    }
}
