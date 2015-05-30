using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theatre.Contracts;
using Theatre.Exceptions;

namespace Theatre.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void TestAddingPerformanceShouldReturnListCorrectrly()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre");
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            string actaulPerformances = string.Join(", ", database.ListAllPerformances());

            string expectedPerformances = "Performance(Theatre: Theatre, Title: Title, Date: 01.01.2015 19:00, Duration: 01:30, Price: 15.50)";
            Assert.AreEqual(actaulPerformances, expectedPerformances);
        }

        [TestMethod]
        public void TestAddingMultiplePerformancesShouldReturnListCorrectrly()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre");
            database.AddTheatre("Theatre2");
            database.AddTheatre("Theatre3");
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            database.AddPerformance("Theatre2", "Title2", new DateTime(2015, 1, 2, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            database.AddPerformance("Theatre3", "Title3", new DateTime(2015, 1, 3, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            string actaulPerformances = string.Join(", ", database.ListAllPerformances());

            string expectedPerformances =
                "Performance(Theatre: Theatre, Title: Title, Date: 01.01.2015 19:00, Duration: 01:30, Price: 15.50)"
                + ", Performance(Theatre: Theatre2, Title: Title2, Date: 02.01.2015 19:00, Duration: 01:30, Price: 15.50)"
                + ", Performance(Theatre: Theatre3, Title: Title3, Date: 03.01.2015 19:00, Duration: 01:30, Price: 15.50)";
            Assert.AreEqual(actaulPerformances, expectedPerformances);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddingPerformanceToNonExsitentTheatreShouldThrowException()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddingOverlappingPerformanceShouldThrowException()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre");
            database.AddTheatre("Theatre2");
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 20, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddingOverlappingPerformanceEndToStartShouldThrowException()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre");
            database.AddTheatre("Theatre2");
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 20, 30, 0), new TimeSpan(1, 30, 0), 15.5m);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddingOverlappingPerformanceStartToEndShouldThrowException()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre");
            database.AddTheatre("Theatre2");
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 19, 0, 0), new TimeSpan(1, 30, 0), 15.5m);
            database.AddPerformance("Theatre", "Title", new DateTime(2015, 1, 1, 20, 00, 0), new TimeSpan(1, 30, 0), 15.5m);
        }

        [TestMethod]
        public void TestPrintNoPerformancesShouldReturnEmptyList()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();

            var actualPerformances = database.ListAllPerformances();
            Assert.AreEqual(0, actualPerformances.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestPrintPerformancesOfNonExsistentTheatreShouldThrowException()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.ListPerformances("Test");
        }

        [TestMethod]
        public void TestPrintPerformancesForTheatreShouldReturnCorrectly()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("First Theatre");
            database.AddPerformance("First Theatre", "Title1", new DateTime(2015, 01, 01, 18, 30, 00), new TimeSpan(01, 00, 00), 15m);
            database.AddPerformance("First Theatre", "Title2", new DateTime(2015, 01, 01, 20, 00, 00), new TimeSpan(01, 00, 00), 15m);

            database.AddTheatre("Second Theatre");
            database.AddPerformance("Second Theatre", "Title1", new DateTime(2015, 01, 01, 18, 30, 00), new TimeSpan(01, 00, 00), 15m);

            var actualPerformances = string.Join(", ", database.ListPerformances("Second Theatre"));
            var expected = "Performance(Theatre: Second Theatre, Title: Title1, Date: 01.01.2015 18:30, Duration: 01:00, Price: 15.00)";
            Assert.AreEqual(actualPerformances, expected);
        }
    }
}
