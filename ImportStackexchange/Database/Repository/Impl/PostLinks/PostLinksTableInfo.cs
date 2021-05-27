namespace ImportStackexchange.Database.Repository.Impl.PostLinks
{
    public class PostLinksTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE post_links (
	id SERIAL PRIMARY KEY,
	related_post_id INTEGER NOT NULL,
	post_id INTEGER NOT NULL,
	link_type_id SMALLINT NOT NULL,
	creation_date TIMESTAMP NOT NULL
);
";

        public string GetTableName() => "post_links";
    }
}
