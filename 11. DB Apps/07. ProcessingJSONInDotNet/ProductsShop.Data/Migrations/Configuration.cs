namespace ProductsShop.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Xml;
    using ProductShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProductsShop.Data.ProductsShopEntities";
        }

        protected override void Seed(ProductsShopEntities context)
        {
            if (!context.Users.Any() && !context.Categories.Any() && !context.Products.Any())
            {
                var random = new Random();
                var serializer = new JavaScriptSerializer();
                LoadUsersAndTheirFriends(context, random);
                LoadCategories(context, serializer);
                LoadProductsAndTheirCategories(context, serializer, random);
                LoadUserProductsSoldAndBought(context, random);
            }
        }

        private static void LoadUserProductsSoldAndBought(ProductsShopEntities context, Random random)
        {
            LoadUserProductsSold(context, random);
            LoadUserProductsBought(context, random);
        }

        private static void LoadUserProductsBought(ProductsShopEntities context, Random random)
        {
            foreach (var user in context.Users)
            {
                for (int i = 0; i < random.Next(3, 11); i++)
                {
                    var product = context.Products.Find(random.Next(1, context.Products.Count()));
                    if (!user.ProductsBought.Contains(product))
                    {
                        user.ProductsBought.Add(product);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void LoadUserProductsSold(ProductsShopEntities context, Random random)
        {
            foreach (var user in context.Users)
            {
                for (int i = 0; i < random.Next(3, 11); i++)
                {
                    var product = context.Products.Find(random.Next(1, context.Products.Count()));
                    if (!user.ProductsSold.Contains(product))
                    {
                        user.ProductsSold.Add(product);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void LoadProductsAndTheirCategories(ProductsShopEntities context, JavaScriptSerializer serializer,
            Random random)
        {
            StreamReader productsReader = new StreamReader("../../products.json");
            var productsJson = productsReader.ReadToEnd();
            var products = serializer.Deserialize<List<Product>>(productsJson);
            foreach (var product in products)
            {
                var seller = context.Users.Find(random.Next(1, context.Users.Count()));
                product.SellerId = seller.Id;
                var hasBuyer = random.Next(0, 2);
                if (hasBuyer == 0)
                {
                    product.BuyerId = null;
                }
                else
                {
                    product.BuyerId = context.Users.Find(random.Next(1, context.Users.Count())).Id;
                }

                for (int i = 0; i < random.Next(1, 4); i++)
                {
                    var category = context.Categories.Find(random.Next(1, context.Categories.Count()));
                    if (!product.Categories.Contains(category))
                    {
                        product.Categories.Add(category);
                    }
                }
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        private static void LoadCategories(ProductsShopEntities context, JavaScriptSerializer serializer)
        {
            StreamReader catagoriesReader = new StreamReader("../../categories.json");
            var categoriesJson = catagoriesReader.ReadToEnd();
            var categories = serializer.Deserialize<List<Category>>(categoriesJson);
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();
        }

        private static void LoadUsersAndTheirFriends(ProductsShopEntities context, Random random)
        {
            LoadUsers(context);
            LoadUsersFriends(context, random);
        }

        private static void LoadUsersFriends(ProductsShopEntities context, Random random)
        {
            foreach (var user in context.Users)
            {
                for (int i = 0; i < random.Next(0, 11); i++)
                {
                    var friend = context.Users.Find(random.Next(1, context.Users.Count()));
                    if (!user.Friends.Contains(friend) && user.Id != friend.Id)
                    {
                        user.Friends.Add(friend);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void LoadUsers(ProductsShopEntities context)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../users.xml");

            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                var lastName = childNode.Attributes["last-name"] != null
                    ? childNode.Attributes["last-name"].Value
                    : null;
                string firstName = childNode.Attributes["first-name"] != null
                    ? childNode.Attributes["first-name"].Value
                    : null;
                int? age = childNode.Attributes["age"] != null
                    ? int.Parse(childNode.Attributes["age"].Value)
                    : (int?) null;

                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
