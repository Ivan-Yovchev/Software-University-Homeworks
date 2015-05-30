namespace Theatre.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Contracts;
    using Exceptions;

    [TestClass]
    public class TheatreTests
    {
        [TestMethod]
        public void TestAddTheatreReturnsListsTheatresCorrectrly()
        {
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Test Theatre");

            var expectedTheatres = new[] {"Test Theatre"};
            var actualTheatres = database.ListTheatres().ToList();

            CollectionAssert.AreEqual(expectedTheatres, actualTheatres);
        }

        [TestMethod]
        public void TestAddTheatreReturnsListsTheatresCorrectrlyOrdered()
        {
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Art Theatre");
            database.AddTheatre("Bart Theatre");
            database.AddTheatre("Theatre 199");

            var expectedTheatres = new[] { "Art Theatre", "Bart Theatre", "Theatre 199" };
            var actualTheatres = database.ListTheatres().ToList();

            CollectionAssert.AreEqual(expectedTheatres, actualTheatres);
        }

        [TestMethod]
        public void TestAddDuplicateTheatresShouldListTheatresCorrectrly()
        {
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Art Theatre");
            database.AddTheatre("Theatre 199");

            try
            {
                database.AddTheatre("Theatre 199");
            }
            catch (Exception)
            {

            }

            var expectedTheatres = new[] { "Art Theatre", "Theatre 199" };
            var actualTheatres = database.ListTheatres().ToList();

            CollectionAssert.AreEqual(expectedTheatres, actualTheatres);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void TestAddDuplicateShouldThrowException()
        {
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Art Theatre");
            database.AddTheatre("Theatre 199");
            database.AddTheatre("Theatre 199");
        }

        [TestMethod]
        public void TestNoTheatresShouldReturnEmptyList()
        {
            IPerformanceDatabase database = new PerformanceDatabase();

            var actualTheatres = database.ListTheatres().ToList();

            Assert.AreEqual(0, actualTheatres.Count());
        }
    }
}
