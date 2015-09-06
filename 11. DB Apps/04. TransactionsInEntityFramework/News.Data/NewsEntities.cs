using News.Data.Migrations;

namespace News.Data
{
    using System.Data.Entity;
    using Models;

    public class NewsEntities : DbContext
    {
        public NewsEntities()
            : base("name=NewsEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsEntities, Configuration>());
        }

        public virtual IDbSet<News> News { get; set; } 
    }
}