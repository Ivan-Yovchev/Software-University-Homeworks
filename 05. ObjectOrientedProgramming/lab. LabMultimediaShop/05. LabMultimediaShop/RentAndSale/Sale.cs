using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;


namespace LabMultimediaShop.RentAndSale
{
    public class Sale : ISaleable
    {
        private IItem item;
        private DateTime saleDate;

        private static List<ISaleable> sales;

        static Sale()
        {
            Sale.sales = new List<ISaleable>();
        }

        public Sale(IItem item, DateTime saleDate)
        {
            this.Item = item;
            this.SaleDate = saleDate;
        }

        public Sale(IItem item)
        {
            this.Item = item;
            this.SaleDate = DateTime.Now;
        }

        public IItem Item
        {
            get
            {
                return this.item;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sale Item cannot be null");
                }
                else
                {
                    this.item = value;
                }
            }
        }

        public DateTime SaleDate
        {
            get
            {
                return this.saleDate;
            }
            set
            {
                this.saleDate = value;
            }
        }

        public static List<ISaleable> Sales
        {
            get
            {
                return new List<ISaleable>(Sale.sales);
            }
        }

        public static void AddSale(ISaleable sale)
        {
            Sale.sales.Add(sale);
        }

        public override string ToString()
        {
            string result = string.Format("- Sale {0:dd-MM-yyyy}\n{1}\n", this.saleDate, item.ToString());

            return result;
        }
    }
}
