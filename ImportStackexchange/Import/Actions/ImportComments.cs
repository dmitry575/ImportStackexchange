using ReaderStackExchangeXml.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Import.Actions
{
  public  class ImportComments : BaseImport<Comment>
    {
        public override TypeFile TypeFile => TypeFile.Comments;

        public ImportComments(IInsertRepository<Comment> t) : base(t)
        {
        }
    }
}