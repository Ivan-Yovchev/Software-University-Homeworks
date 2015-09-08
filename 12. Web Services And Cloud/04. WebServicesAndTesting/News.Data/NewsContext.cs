namespace News.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("NewsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsContext, Configuration>());
        }

        public IDbSet<NewsItem> News { get; set; }
    }
}