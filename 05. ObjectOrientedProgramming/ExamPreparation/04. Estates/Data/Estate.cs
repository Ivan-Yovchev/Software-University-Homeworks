namespace Estates.Data
{

    using System;
    using System.Text;
    using Estates.Interfaces;

    public abstract class Estate : IEstate
    {
        private string name;
        private double area;
        private string location;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of an estate is required");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public EstateType Type { get; set; }
        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("Estate area must be in the range [0...10000]");
                }
                else
                {
                    this.area = value;
                }
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The location of an estate is required");
                }
                else
                {
                    this.location = value;
                }
            }
        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            StringBuilder estate = new StringBuilder();
            estate
                .AppendFormat("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", this.Type, this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No");

            return estate.ToString();
        }
    }
}
