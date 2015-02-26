namespace Estates.Data
{
    using System;
    using System.Text;
    using Estates.Interfaces;

    public class House : Estate, IHouse
    {
        private int floors;

        public House()
        {
            this.Type = EstateType.House;
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("House floors must be in the range [0...10]");
                }
                else
                {
                    this.floors = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder house = new StringBuilder();
            house
                .Append(base.ToString())
                .AppendFormat(", Floors: {0}", this.Floors);

            return house.ToString();
        }
    }
}
