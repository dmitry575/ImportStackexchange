namespace ImportStackexchange.Database.Repository.Impl.Users
{
    public class UsersTableInfo : ICheckTableInfo
    {
        public string GetSqlCreateTable() => @"CREATE TABLE users (
	id SERIAL PRIMARY KEY,
	account_id INTEGER,
	reputation INTEGER NOT NULL,
	views INTEGER DEFAULT 0,
	down_votes INTEGER DEFAULT 0,
	up_votes INTEGER DEFAULT 0,
	display_name VARCHAR(255) NOT NULL,
	location VARCHAR(512),
	profile_image_url VARCHAR(255),
	website_url VARCHAR(255),
	about_me TEXT,
	creation_date TIMESTAMP NOT NULL,
	last_access_date TIMESTAMP
);
";

        public string GetTableName() => "users";
    }
}
