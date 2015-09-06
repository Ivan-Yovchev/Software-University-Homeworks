namespace ProductsShop.Data
{
    using Migrations;
    using ProductShop.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ProductsShopEntities : DbContext
    {
        public ProductsShopEntities()
            : base("ProductsShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopEntities, Configuration>());
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("UserFriends");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}