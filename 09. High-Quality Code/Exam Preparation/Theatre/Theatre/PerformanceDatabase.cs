namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Contracts;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theatres =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.theatres.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException(Constants.DuplicateTheatreMessage);
            }

            this.theatres[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatreNames = this.theatres.Keys;
            return theatreNames;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.theatres.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreNotFoundMessage);
            }

            var performances = this.theatres[theatreName];
            var endTime = startDateTime + duration;
            if (CheckForOverlappingTime(performances, startDateTime, endTime))
            {
                throw new TimeDurationOverlapException(Constants.TimeDurationOverlapMessage);
            }

            var performance = new Performance(theatreName, performanceTitle, startDateTime, duration, price);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var allPerformances = new List<Performance>();
            foreach (var theatre in this.theatres.Keys)
            {
                var performances = this.theatres[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theatres.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreNotFoundMessage);
            }

            var performances = this.theatres[theatreName];
            return performances;
        }

        private bool CheckForOverlappingTime(IEnumerable<Performance> performances, DateTime otherStartTime, DateTime otherEndTime)
        {
            var isOverlapping = false;
            foreach (var performance in performances)
            {
                var startTime = performance.Date;
                var endTime = startTime + performance.Duration;
                var compareResult = (startTime > otherEndTime) || (endTime < otherStartTime);
                if (compareResult == false)
                {
                    isOverlapping = true;
                    break;
                }
            }

            return isOverlapping;
        }
    }
}
