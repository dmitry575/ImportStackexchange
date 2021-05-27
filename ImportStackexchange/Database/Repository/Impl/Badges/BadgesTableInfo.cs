
namespace ImportStackexchange.Database.Repository.Impl.Badges
{
    public class BadgesTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE badges (

    id SERIAL PRIMARY KEY,
    user_id INTEGER NOT NULL,

    class SMALLINT NOT NULL,
    name VARCHAR(64) NOT NULL,
    tag_based BOOL NOT NULL,
	date TIMESTAMP NOT NULL
);
";

        public string GetTableName() => "badges";
    }
}
