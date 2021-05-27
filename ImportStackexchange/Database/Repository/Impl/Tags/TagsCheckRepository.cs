using System.Data;

namespace ImportStackexchange.Database.Repository.Impl.Tags
{
    public class TagsCheckRepository : BaseCheckRepository<TagsTableInfo>
    {
        public TagsCheckRepository(TagsTableInfo info, IDbConnection connection) : base(info, connection)
        {
        }
    }
}
