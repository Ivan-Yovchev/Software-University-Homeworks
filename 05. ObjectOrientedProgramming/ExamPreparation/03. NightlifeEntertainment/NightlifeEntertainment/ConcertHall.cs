namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;

    class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Theatre, PerformanceType.Concert, PerformanceType.Opera })
        {
        }
    }
}
