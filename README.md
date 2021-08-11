# Import StackExchange XML files to database 


## INSTALLATION
```
dotnet publish -c Release -o ./publish
```

If  you want build application to one exe file on windows:

```
dotnet publish -c Release -r win-x64 -o ./publish /p:PublishSingleFile=true /p:PublishTrimmed=true
```

## USAGE

First, you need change connection string to database in configuration file, application use only **PostgresSQL**:

```
appsettings.json
```

Default configuration of connection to database:

```
"DefaultConnection": "Host=localhost;Port=15432;Database=postgres;Username=postgres;Password=postgres;Encoding=UTF8;Pooling=true;Maximum Pool Size=150;Timeout=300;CommandTimeout=300"
```

Application parammetrs:

```
  -t, --type     (Default: All) Set type of file: All, Votes, Users, Tags, PostLinks, Posts, PostHistory, Comments, Badges
  -c, --check    (Default: true) Set flag checking tables and create before insert
  -p, --path     (Default: ./) Set paths where xml files
  --help         Display this help screen.
  --version      Display version information.
  ```
