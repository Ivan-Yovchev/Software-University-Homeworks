namespace Theatre.Contracts
{
    using System;
    using System.Collections.Generic;
    using Exceptions;

    /// <summary>
    /// Defines a database of theatres and performances for each theatre
    /// with add/list logic for the theatres and performnaces
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the database
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        /// <exception cref="TheatreNotFoundException">Thrown in case of duplicate theatre
        /// Holds a "Duplicate theatre" as error message</exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Displays theatres ordered by name
        /// </summary>
        /// <returns>An ordered list of theatre names</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds a performance to a given theatre
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        /// <param name="performanceTitle">The title of the performance</param>
        /// <param name="startDateTime">The start date of the performance</param>
        /// <param name="duration">The duration of the performance</param>
        /// <param name="price">The price of the ticket for the performance</param>
        /// <exception cref="TimeDurationOverlapException">Thrown in case of overlapping performances
        /// with "Time/duration overlap" error message</exception>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Lists all performances from every theatre ordered by name (as first criteria)
        /// and by start date as a second criteria
        /// </summary>
        /// <returns>An ordered list of performance names</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Lists all performances for a given theatre ordered by start date
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        /// <returns>A ordered list of performance names</returns>
        /// <exception cref="TheatreNotFoundException">Thrown in case theatre name is not found
        /// with "Theatre not found" error message</exception>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
