using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace ImportStackexchange.Database.Repository.Impl
{
    public abstract class BaseInsertRepository<T> : BaseRepository, IInsertRepository<T> where T : class, new()
    {

        public BaseInsertRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public abstract string GetInsertSql();

        public void InsertBulk(IEnumerable<T> list)
        {
            var trans = _connection.BeginTransaction();
            try
            {
                _connection.Execute(GetInsertSql(), list, transaction: trans);
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }

        }
    }
}
