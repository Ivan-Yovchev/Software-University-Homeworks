using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;


namespace LabMultimediaShop.Items
{
    public class Video : Item
    {
        private int length;

        public Video(string id, string title, decimal price, int length, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Length = length;
        }

        public Video(string id, string title, decimal price, int length, string genre)
            : base(id, title, price, new List<string>() { genre })
        {
            this.Length = length;
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Movie Length cannot be a negative number or zero");
                }
                else
                {
                    this.length = value;
                }
            }
        }

        public override string ToString()
        {
            string result = string.Format("Video {0}Length: {1}\n", base.ToString(), this.length);

            return result;
        }
    }
}
