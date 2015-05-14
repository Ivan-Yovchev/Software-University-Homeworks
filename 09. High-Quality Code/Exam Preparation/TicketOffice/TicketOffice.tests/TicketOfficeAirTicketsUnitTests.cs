using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketOffice.tests
{
    [TestClass]
    public class TicketOfficeAirTicketsUnitTests
    {
        [TestMethod]
        public void TestAddAirTickedReturnsTickedAdded()
        {
            ITicketRepository repository = new TicketRepository();

            string cmdResult = repository.AddAirTicket(flightNumber: "FS123", from: "Paris", to: "Sofia",
                airline: "N-air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 123.5m);

            Assert.AreEqual("Flight created", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Flight));
        }
    }
}
