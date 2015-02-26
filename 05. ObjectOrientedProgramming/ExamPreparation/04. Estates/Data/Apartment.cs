namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
        {
            base.Type = EstateType.Apartment;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
