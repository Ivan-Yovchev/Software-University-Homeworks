using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;


namespace LabMultimediaShop.Items
{
    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genre)
            : base(id, title, price, new List<string>() { genre })
        {
            this.Author = author;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Author Name must be non-empty string");
                }
                else if (value.Length < 3)
                {
                    throw new FormatException("The Author Name must be at least 3 symbols long");
                }
                else
                {
                    this.author = value;
                }
            }
        }

        public override string ToString()
        {
            string result = string.Format("Book {0}Author: {1}\n", base.ToString(), this.author);

            return result;
        }
    }
}
