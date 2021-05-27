namespace ImportStackexchange.Database.Repository.Impl.Comments
{
    public class CommentsTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE comments (
	id SERIAL PRIMARY KEY,
	post_id INTEGER NOT NULL,
	user_id INTEGER,
	score SMALLINT NOT NULL,
	content_license VARCHAR(64) NOT NULL,
	text TEXT,
	creation_date TIMESTAMP NOT NULL
);
";

        public string GetTableName() => "comments";
    }
}
