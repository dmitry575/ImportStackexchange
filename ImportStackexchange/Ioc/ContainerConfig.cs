using ImportStackexchange.Database;
using ImportStackexchange.Database.Models;
using ImportStackexchange.Database.Repository;
using ImportStackexchange.Database.Repository.Impl;
using ImportStackexchange.Database.Repository.Impl.Badges;
using ImportStackexchange.Database.Repository.Impl.Comments;
using ImportStackexchange.Database.Repository.Impl.PostHistory;
using ImportStackexchange.Database.Repository.Impl.PostLinks;
using ImportStackexchange.Database.Repository.Impl.Posts;
using ImportStackexchange.Database.Repository.Impl.Tags;
using ImportStackexchange.Database.Repository.Impl.Users;
using ImportStackexchange.Database.Repository.Impl.Votes;
using ImportStackexchange.Import;
using ImportStackexchange.Import.Actions;
using ImportStackexchange.Import.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using System.Threading;

namespace ImportStackexchange.Ioc
{
    public static class ContainerConfig
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddConnection(configuration)
                .AddRepositories()
                .AddCheckTables()
                .AddParsers()
                .AddCancelToken();
        }


        private static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(provider =>
            {
                var s = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
                s.Open();
                return s;
            });
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                    .AddTransient<CheckingTables, CheckingTables>()
                    .AddTransient<UsersRepository, UsersRepository>()
                    .AddTransient<BadgesRepository, BadgesRepository>()
                    .AddTransient<PostsRepository, PostsRepository>()
                    .AddTransient<PostLinksRepository, PostLinksRepository>()
                    .AddTransient<PostHistoryRepository, PostHistoryRepository>()
                    .AddTransient<CommentsRepository, CommentsRepository>()
                    .AddTransient<VotesRepository, VotesRepository>()
                    .AddTransient<TagsRepository, TagsRepository>()
                    .AddTransient<IInsertRepository<Tag>, TagsRepository>()
                    .AddTransient<IInsertRepository<User>, UsersRepository>()
                    .AddTransient<IInsertRepository<Badge>, BadgesRepository>()
                    .AddTransient<IInsertRepository<Post>, PostsRepository>()
                    .AddTransient<IInsertRepository<PostLink>, PostLinksRepository>()
                    .AddTransient<IInsertRepository<PostHistory>, PostHistoryRepository>()
                    .AddTransient<IInsertRepository<Comment>, CommentsRepository>()
                    .AddTransient<IInsertRepository<Vote>, VotesRepository>()
                    ;
        }

        private static IServiceCollection AddCancelToken(this IServiceCollection services)
        {
            return
                services.AddSingleton(x => new CancellationTokenSource());
        }

        public static IServiceCollection AddCheckTables(this IServiceCollection services)
        {
            return services
                .AddTransient<BadgesTableInfo, BadgesTableInfo>()
                .AddScoped<ICheckRepository, BadgesCheckRepository>()

                .AddTransient<UsersTableInfo, UsersTableInfo>()
                .AddScoped<ICheckRepository, UsersCheckRepository>()

                .AddTransient<PostsTableInfo, PostsTableInfo>()
                .AddScoped<ICheckRepository, PostsCheckRepository>()

                .AddTransient<PostLinksTableInfo, PostLinksTableInfo>()
                .AddScoped<ICheckRepository, PostLinksCheckRepository>()

                .AddTransient<PostHistoryTableInfo, PostHistoryTableInfo>()
                .AddScoped<ICheckRepository, PostHistoryCheckRepository>()

                .AddTransient<CommentsTableInfo, CommentsTableInfo>()
                .AddScoped<ICheckRepository, CommentsCheckRepository>()

                .AddTransient<VotesTableInfo, VotesTableInfo>()
                .AddScoped<ICheckRepository, VotesCheckRepository>()

                .AddTransient<TagsTableInfo, TagsTableInfo>()
                .AddScoped<ICheckRepository, TagsCheckRepository>();
        }

        public static IServiceCollection AddParsers(this IServiceCollection services)
        {
            return services
                .AddTransient<ImportXmlFiles, ImportXmlFiles>()
                .AddSingleton<IImportFactory, ImportFactory>()
                .AddTransient<IImportFile, ImportTags>()
                .AddTransient<IImportFile, ImportComments>()
                .AddTransient<IImportFile, ImportBadges>()
                .AddTransient<IImportFile, ImportPostHistory>()
                .AddTransient<IImportFile, ImportPostLinks>()
                .AddTransient<IImportFile, ImportPosts>()
                .AddTransient<IImportFile, ImportUsers>()
                .AddTransient<IImportFile, ImportVotes>();
        }

        private static IServiceCollection AddImport<T, TService>(this IServiceCollection services)
           where T : class
           where TService : BaseImport<T>
        {
            return services.AddTransient<BaseImport<T>, TService>();
        }
    }
}
