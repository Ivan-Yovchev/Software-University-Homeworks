namespace Estates.Data
{
    using System;
    using System.Text;
    using Estates.Interfaces;

    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer()
        {
            this.Type = OfferType.Rent;
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price per month cannot be negative or zero");
                }
                else
                {
                    this.pricePerMonth = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder rentOffer = new StringBuilder();
            rentOffer
                .Append(base.ToString())
                .AppendFormat(", Price = {0}", this.PricePerMonth);

            return rentOffer.ToString();
        }
    }
}
