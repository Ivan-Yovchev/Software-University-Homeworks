namespace BookShopSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            if (!context.Authors.Any() && !context.Books.Any() && !context.Categories.Any())
            {
                var random = new Random();
                CreateAllCategories(context);
                CreateAllAuthors(context);
                CreateAllBooks(context, random);
            }
        }

        private static void CreateAllBooks(BookShopContext context, Random random)
        {
            using (var reader = new StreamReader("../../../BookShopSystemFiles/books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 6);
                    var authorIndex = random.Next(1, context.Authors.Count());
                    var author = context.Authors.Find(authorIndex);
                    var edition = (EditionType) int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction) int.Parse(data[4]);
                    var title = data[5];

                    var book = new Book()
                    {
                        Author = author,
                        Edition = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    };

                    for (int i = 0; i < random.Next(1, 6); i++)
                    {
                        var category = context.Categories.Find(random.Next(1, context.Categories.Count()));
                        if (!book.Categories.Contains(category))
                        {
                            book.Categories.Add(category);
                        }
                    }

                    context.Books.Add(book);

                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }

        private static void CreateAllAuthors(BookShopContext context)
        {
            using (var reader = new StreamReader("../../../BookShopSystemFiles/authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 2);
                    var firstName = data[0];
                    var lastName = data[1];

                    var author = new Author()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };
                    context.Authors.Add(author);

                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }

        private static void CreateAllCategories(BookShopContext context)
        {
            using (var reader = new StreamReader("../../../BookShopSystemFiles/categories.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var category = new Category()
                    {
                        Name = line.Trim()
                    };
                    context.Categories.Add(category);
                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }
    }
}
