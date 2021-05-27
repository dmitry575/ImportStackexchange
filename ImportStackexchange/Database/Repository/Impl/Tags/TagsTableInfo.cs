namespace ImportStackexchange.Database.Repository.Impl.Tags
{
    public class TagsTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE tags (
	id SERIAL PRIMARY KEY,
	excerpt_post_id INTEGER,
	wiki_post_id INTEGER,
	tag_name VARCHAR(255) NOT NULL,
	count INTEGER DEFAULT 0
);
";

        public string GetTableName() => "tags";
    }
}
