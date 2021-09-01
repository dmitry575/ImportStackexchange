namespace ImportStackexchange.Database.Repository.Impl.PostHistories
{
    public class PostHistoryTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE post_history (
	id SERIAL PRIMARY KEY,
	post_id INTEGER NOT NULL,
	user_id INTEGER,
	post_history_type_id SMALLINT NOT NULL,
	user_display_name VARCHAR(64),
	content_license VARCHAR(64),
	revision_guid uuid,
	text TEXT,
	comment TEXT,
	creation_date TIMESTAMP NOT NULL
);
";

        public string GetTableName() => "post_history";
    }
}
