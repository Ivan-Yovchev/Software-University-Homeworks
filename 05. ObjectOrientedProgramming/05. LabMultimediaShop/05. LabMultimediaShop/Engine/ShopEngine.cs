using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;
using LabMultimediaShop.RentAndSale;
using LabMultimediaShop.SuppliesException;

namespace LabMultimediaShop.Engine
{
    public class ShopEngine
    {
        private static Dictionary<IItem, int> supplies;

        static ShopEngine()
        {
            ShopEngine.supplies = new Dictionary<IItem, int>();
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "break")
                {
                    break;
                }
                else
                {
                    ExtractSupplyInformation(command);
                }
            }
        }

        private void ExtractSupplyInformation(string command)
        {
            string[] splitCommand = command.Split(' ');
            if (splitCommand[0] == "supply")
            {
                IItem createdItem = CreateSuppliedItem(splitCommand[1], splitCommand[3]);
                ShopEngine.supplies.Add(createdItem, int.Parse(splitCommand[2]));
            }
            else if (splitCommand[0] == "sell")
            {
                ISaleable newSale = SaleItem(splitCommand[1], splitCommand[2]);
                Sale.AddSale(newSale);
            }
            else if (splitCommand[0] == "rent")
            {
                IRentable newRent = RentItem(splitCommand[1], splitCommand[2], splitCommand[3]);
                Rent.AddRent(newRent);
            }
            else if (splitCommand[0] == "report")
            {
                if (splitCommand[1] == "rents")
                {
                    var rents = Rent.Rents
                        .Where(rent => rent.RentState == RentStatus.Overdue)
                        .OrderBy(rent => rent.RentFine)
                        .ThenBy(rent => rent.Item.Title);
                    foreach (var report in rents)
                    {
                        Console.WriteLine(report);
                    }
                }
                else if (splitCommand[1] == "sales")
                {
                    string[] splitData = splitCommand[2].Split('-');
                    DateTime lastSaleDate = new DateTime(int.Parse(splitData[2]), int.Parse(splitData[1]), int.Parse(splitData[0]));
                    decimal sum = Sale.Sales
                        .Where(sale => sale.SaleDate >= lastSaleDate)
                        .Sum(sale => sale.Item.Price);

                    Console.WriteLine("{0:N2}", sum);
                }
            }
        }

        private IRentable RentItem(string id, string dateOfRent, string deadlineDate)
        {
            string[] splitDateOfRent = dateOfRent.Split('-');
            DateTime rentDate = new DateTime(int.Parse(splitDateOfRent[2]), int.Parse(splitDateOfRent[1]), int.Parse(splitDateOfRent[0]));

            string[] splitDeadline = deadlineDate.Split('-');
            DateTime deadline = new DateTime(int.Parse(splitDeadline[2]), int.Parse(splitDeadline[1]), int.Parse(splitDeadline[0]));

            IRentable rent = null;
            foreach (KeyValuePair<IItem, int> item in supplies)
            {
                if (item.Key.ID == id)
                {
                    if (item.Value > 0)
                    {
                        supplies[item.Key] = supplies[item.Key] - 1;
                        rent = new Rent(item.Key, rentDate, deadline);
                    }
                    else
                    {
                        throw new InsufficientSuppliesException("Item is not in supply");
                    }
                    break;
                }
            }

            return rent;
        }

        private ISaleable SaleItem(string id, string purchaseDate)
        {
            string[] splitDate = purchaseDate.Split('-');
            DateTime saleDate = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));

            ISaleable sale = null;
            foreach (KeyValuePair<IItem, int> item in supplies)
            {
                if (item.Key.ID == id)
                {
                    if (item.Value > 0)
                    {
                        supplies[item.Key] = supplies[item.Key] - 1;
                        sale = new Sale(item.Key, saleDate);
                    }
                    else
                    {
                        throw new InsufficientSuppliesException("Item is not in supply");
                    }
                    break;
                }
            }

            return sale;
        }

        private IItem CreateSuppliedItem(string itemType, string itemSpecifications)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] pairs = itemSpecifications.Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

            IItem item = null;
            switch (itemType)
            {
                case "book": item = new Book(
                    keyValuePairs["id"],
                    keyValuePairs["title"], 
                    decimal.Parse(keyValuePairs["price"]),
                    keyValuePairs["author"], 
                    new List<string>() { keyValuePairs["genre"] }); 
                    break;
                case "game": item = new Game(
                    keyValuePairs["id"],
                    keyValuePairs["title"],
                    decimal.Parse(keyValuePairs["price"]),
                    new List<string>() { keyValuePairs["genre"] },
                    (AgeRestriction)Enum.Parse(typeof(AgeRestriction), keyValuePairs["ageRestriction"]));
                    break;
                case "video": item = new Video(
                    keyValuePairs["id"],
                    keyValuePairs["title"],
                    decimal.Parse(keyValuePairs["price"]),
                    int.Parse(keyValuePairs["length"]),
                    new List<string>() { keyValuePairs["genre"] });
                    break;
            }

            return item;
        }

    }
}
