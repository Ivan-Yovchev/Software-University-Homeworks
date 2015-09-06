namespace ProductsShop.ConsoleClient
{
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Data;
    using System.Xml.Linq;

    class ProductsShopMain
    {
        static void Main()
        {
            var context = new ProductsShopEntities();
            var serializer = new JavaScriptSerializer();
            // GetProductsInRange(context, serializer);
            // GetSuccessfullySoldProducts(context, serializer);
            // GetCategoriesByProductsCount(context, serializer);
            // GetUsersAndProductsXml(context);
        }

        private static void GetUsersAndProductsXml(ProductsShopEntities context)
        {
            XDocument doc = new XDocument();
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count())
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    products = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price
                    })
                });

            XElement root = new XElement("users", new XAttribute("count", users.Count().ToString()));
            doc.Add(root);
            foreach (var user in users)
            {
                XElement userElement = new XElement("user");
                if (user.firstName != null)
                {
                    XAttribute firstNameAttribute = new XAttribute("first-name", user.firstName);
                    userElement.Add(firstNameAttribute);
                }

                XAttribute lastNameAttribute = new XAttribute("last-name", user.lastName);
                userElement.Add(lastNameAttribute);

                if (user.age != null)
                {
                    XAttribute ageAttribute = new XAttribute("age", user.age);
                    userElement.Add(ageAttribute);
                }

                XElement soldProductsElement = new XElement("sold-products", new XAttribute("count", user.products.Count()));
                foreach (var product in user.products)
                {
                    XElement productElement = new XElement("product");
                    if (product.name != null)
                    {
                        XAttribute nameAttribute = new XAttribute("name", product.name);
                        productElement.Add(nameAttribute);
                    }

                    if (product.price != null)
                    {
                        XAttribute priceAttribute = new XAttribute("price", product.price);
                        productElement.Add(priceAttribute);
                    }
                    soldProductsElement.Add(productElement);
                }
                userElement.Add(soldProductsElement);
                root.Add(userElement);
            }
            doc.Save("../../users-and-products.xml");
        }

        private static void GetCategoriesByProductsCount(ProductsShopEntities context, JavaScriptSerializer serializer)
        {
            var categories = context.Categories
                .OrderBy(c => c.Products.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count(),
                    averagePrice = c.Products.Average(p => (decimal?) p.Price),
                    totalRevenue = c.Products.Sum(p => (decimal?) p.Price)
                });

            var json = serializer.Serialize(categories);
            var writer = new StreamWriter("../../categories-by-products-count.json");
            writer.Write(json);
            writer.Close();
        }

        private static void GetSuccessfullySoldProducts(ProductsShopEntities context, JavaScriptSerializer serializer)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count() != 0 && u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                });

            var json = serializer.Serialize(users);
            var writer = new StreamWriter("../../successfully-sold-products.json");
            writer.Write(json);
            writer.Close();
        }

        private static void GetProductsInRange(ProductsShopEntities context, JavaScriptSerializer serializer)
        {
            const decimal lowerBound = 500;
            const decimal upperBound = 1000;
            var products = context.Products
                .Where(p => p.Price >= lowerBound && p.Price <= upperBound && p.Buyer == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = (p.Seller.FirstName + " " + p.Seller.LastName).Trim()
                });

            var writer = new StreamWriter("../../products-in-range.json");
            var json = serializer.Serialize(products);
            writer.Write(json);
            writer.Close();
        }
    }
}
