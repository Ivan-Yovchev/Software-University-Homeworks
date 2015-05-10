using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelAgency.tests
{
    [TestClass]
    public class TicketCatalogAirTicketsUnitTests
    {
        [TestMethod]
        public void TestAddAirTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();
            string cmdResult = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
