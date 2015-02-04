using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabMultimediaShop.Items
{
    public abstract class Item : IItem
    {
        private string id, title;
        private decimal price;
        private List<string> genres;

        private static List<string> UniqueIDs;

        static Item()
        {
            Item.UniqueIDs = new List<string>();
        }

        public Item(string id, string title, decimal price, List<string> genres)
        {
            this.ID = id;
            this.Title = title;
            this.Price = price;
            this.Genres = genres;
        }

        public Item(string id, string title, decimal price)
        {
            this.ID = id;
            this.Title = title;
            this.Price = price;
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Item ID must be a non-empty string");
                }
                else if (value.Length < 4)
                {
                    throw new FormatException("The Item ID must be at least 4 symbols long");
                }
                else if (Item.UniqueIDs.Contains(value))
                {
                    throw new ArgumentException(string.Format("This Item ID: {0} is already taken"), value);
                }
                else
                {
                    this.id = value;
                    Item.UniqueIDs.Add(value);
                }
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Item Title must be a non-empty string");
                }
                else
                {
                    this.title = value;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Item Price cannot be a negative number");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public List<string> Genres
        {
            get
            {
                return this.genres;
            }
            set
            {
                this.genres = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format(" {0}\nTitle: {1}\nPrice: {2:N2}\nGenres: {3}\n",
                this.id, this.title, this.price, string.Join(" ", this.genres));

            return result;
        }
    }
}
