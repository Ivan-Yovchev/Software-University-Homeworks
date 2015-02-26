using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ExtendedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            IEstate estate = null;

            switch(type)
            {
                case EstateType.Apartment: estate = new Apartment(); break;
                case EstateType.Office: estate = new Office(); break;
                case EstateType.Garage: estate = new Garage(); break;
                case EstateType.House: estate = new House(); break;
            }

            return estate;
        }

        public static IOffer CreateOffer(OfferType type)
        {
            IOffer offer = null;

            switch (type)
            {
                case OfferType.Rent: offer = new RentOffer(); break;
                case OfferType.Sale: offer = new SaleOffer(); break;
            }

            return offer;
        }
    }
}
