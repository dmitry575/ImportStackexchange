using System.Collections.Generic;

namespace ImportStackexchange.Database.Repository
{
    /// <summary>
    /// Insert data to Database
    /// </summary>
    /// <typeparam name="T"> is class like Tag, Badge and so on</typeparam>
    public interface IInsertRepository<in T> where T : class
    {
        void InsertBulk(IEnumerable<T> list);

        string GetInsertSql();
    }
}
