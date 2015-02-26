namespace Estates.Data
{
    using System;
    using System.Text;
    using Estates.Interfaces;

    public abstract class Offer : IOffer
    {
        private IEstate estate;

        public OfferType Type { get; set; }

        public IEstate Estate
        {
            get
            {
                return this.estate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Estate cannot be null");
                }
                else
                {
                    this.estate = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder offer = new StringBuilder();
            offer
                .AppendFormat("{0}: Estate = {1}, Location = {2}", this.Type, this.Estate.Name, this.Estate.Location);

            return offer.ToString();
        }
    }
}
