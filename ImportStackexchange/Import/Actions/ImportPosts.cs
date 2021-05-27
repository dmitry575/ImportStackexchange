using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
    public class ImportPosts : BaseImport<Post>
    {
        public override TypeFile TypeFile => TypeFile.Posts;

        public ImportPosts(IInsertRepository<Post> t) : base(t)
        {
        }
    }
}