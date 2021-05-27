using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace ImportStackexchange.Database.Repository.Impl
{
    public class BaseCheckRepository<TInfo> : ICheckRepository where TInfo : ICheckTableInfo
    {
        private readonly IDbConnection _connection;
        private readonly TInfo _info;

        public BaseCheckRepository(TInfo info, IDbConnection connection)
        {
            _info = info;
            _connection = connection;
        }

        public async Task<bool> TableExistsAsync()
        {
            var sql = string.Format(SqlTemplates.ExistsTable, _info.GetTableName());
            var res = await _connection.QueryFirstAsync<int>(sql);
            return res == 1;
        }

        public async Task<bool> CreateTableAsync()
        {
            var res = await _connection.ExecuteAsync(_info.GetSqlCreateTable());
            return res == 1;
        }
    }
}
