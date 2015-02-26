namespace Estates.Data
{
    using System;
    using System.Text;
    using Estates.Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or zero");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder saleOffer = new StringBuilder();
            saleOffer
                .Append(base.ToString())
                .AppendFormat(", Price = {0}", this.Price);

            return saleOffer.ToString();
        }
    }
}
