using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
    /// <summary>
    /// Import tags to database
    /// </summary>
    public class ImportTags : BaseImport<Tag>
    {
        public override TypeFile TypeFile => TypeFile.Tags;
     
        public ImportTags(IInsertRepository<Tag> t) : base(t)
        {
        }
    }
}
