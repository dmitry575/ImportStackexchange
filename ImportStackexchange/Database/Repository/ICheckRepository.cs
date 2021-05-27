using System.Threading.Tasks;

namespace ImportStackexchange.Database.Repository
{
    public interface ICheckRepository
    {
        /// <summary>
        /// Check table exists
        /// </summary>
        Task<bool> TableExistsAsync();

        /// <summary>
        /// Create table
        /// </summary>
        Task<bool> CreateTableAsync();
    }
}
