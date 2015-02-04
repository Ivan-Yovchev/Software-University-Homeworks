using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;


namespace LabMultimediaShop.RentAndSale
{
    public class Rent : IRentable
    {
        private IItem item;
        private RentStatus rentState;
        private DateTime rentDate, deadline, returnDate;

        private static List<IRentable> rents;

        static Rent()
        {
            Rent.rents = new List<IRentable>();
        }

        public Rent(IItem item, DateTime rentDate, DateTime deadline)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = deadline;
            if (DateTime.Now <= this.Deadline)
            {
                this.RentState = RentStatus.Pending;
            }
            else
            {
                this.RentState = RentStatus.Overdue;
            }
        }

        public Rent(IItem item, DateTime rentDate)
            : this(item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(IItem item)
            : this(item, DateTime.Now, DateTime.Now.AddDays(30))
        {
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
                    throw new ArgumentNullException("Rent Item cannot be null");
                }
                else
                {
                    this.item = value;
                }
            }
        }

        public RentStatus RentState
        {
            get
            {
                return this.rentState;
            }
            set
            {
                this.rentState = value;
            }
        }

        public DateTime RentDate
        {
            get
            {
                return this.rentDate;
            }
            set
            {
                this.rentDate = value;
            }
        }

        public DateTime Deadline
        {
            get
            {
                return this.deadline;
            }
            set
            {
                this.deadline = value;
            }
        }

        public DateTime ReturnDate
        {
            get
            {
                if (this.rentState != RentStatus.Returned)
                {
                    throw new ArgumentException("Product not returned");
                }
                else
                {
                    return this.returnDate;
                }
            }
            set
            {
                this.returnDate = value;
            }
        }

        public decimal RentFine
        {
            get
            {
                decimal fine = 0m;
                if (this.rentState != RentStatus.Pending)
                {
                    int fineInPercent = (DateTime.Now - this.deadline).Days;
                    fine = (item.Price * fineInPercent) / 100;
                }

                return fine;
            }
        }

        public static List<IRentable> Rents 
        {
            get
            {
                return new List<IRentable>(Rent.rents);
            }
        }

        public void ReturnItem()
        {
            this.rentState = RentStatus.Returned;
            this.returnDate = DateTime.Now;
        }

        public static void AddRent(IRentable item)
        {
            Rent.rents.Add(item);
        }

        public override string ToString()
        {
            string result = string.Format("- Sale {0}\n{1}Rent Fine: {2:N2}\n", this.rentState, item.ToString(), this.RentFine);

            return result;
        }
    }
}
