namespace Estates.Data
{
    using System;
    using System.Text;
    using Estates.Interfaces;

    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public Garage()
        {
            this.Type = EstateType.Garage;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentException("Garage width must be in the range [0...500]");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentException("Garage height must be in the range [0...500]");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder garage = new StringBuilder();
            garage
                .Append(base.ToString())
                .AppendFormat(", Width: {0}, Height: {1}", this.Width, this.Height);

            return garage.ToString();
        }
    }
}
