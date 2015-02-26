namespace Estates.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Estates.Engine;
    using Estates.Interfaces;

    class ExtendedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    decimal minPrice = decimal.Parse(cmdArgs[0]);
                    decimal maxPrice = decimal.Parse(cmdArgs[1]);
                    return this.ExecuteFindRentsByPrice(minPrice, maxPrice);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPrice(decimal minPrice, decimal maxPrice)
        {
            var offers =
                this.Offers
                .Where(r => r is RentOffer)
                .Cast<IRentOffer>()
                .Where(r => r.PricePerMonth >= minPrice && r.PricePerMonth <= maxPrice)
                .OrderBy(r => r.PricePerMonth)
                .ThenBy(r => r.Estate.Name);

            return base.FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);

            return base.FormatQueryResults(offers);
        }
    }
}
