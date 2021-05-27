namespace ImportStackexchange.Database.Repository.Impl.Votes
{
    public class VotesTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE votes (
	id SERIAL PRIMARY KEY,
	user_id INTEGER,
	post_id INTEGER NOT NULL,
	vote_type_id SMALLINT NOT NULL,
	bounty_amount SMALLINT,
	creation_date TIMESTAMP NOT NULL
);
";

        public string GetTableName() => "votes";
    }
}
