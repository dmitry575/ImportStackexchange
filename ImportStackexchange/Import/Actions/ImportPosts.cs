using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;
using ReaderStackExchangeXml;

namespace ImportStackexchange.Import.Actions
{
    public class ImportPosts : BaseImport<Post>
    {
        public override TypeFile TypeFile => TypeFile.Posts;

        public ImportPosts(IInsertRepository<Post> repo, IReaderStackExchangeXml<Post> reader) : base(repo, reader)
        {
        }
    }
}