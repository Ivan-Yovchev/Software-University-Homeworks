namespace BookShopSystem.Data
{
    using Models;
    using Migrations;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookShopContext : IdentityDbContext<ApplicationUser>
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }

        public virtual  IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
    }
}