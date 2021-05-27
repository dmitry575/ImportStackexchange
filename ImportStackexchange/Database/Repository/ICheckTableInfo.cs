
namespace ImportStackexchange.Database.Repository
{
    public interface ICheckTableInfo
    {
        /// <summary>
        /// Getting table name for check
        /// </summary>
        string GetTableName();

        /// <summary>
        /// Get SQL script for creating table
        /// </summary>
        string GetSqlCreateTable();
    }
}
