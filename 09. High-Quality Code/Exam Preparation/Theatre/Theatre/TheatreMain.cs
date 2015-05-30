namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Contracts;

    class TheatreMain
    {
        public static IPerformanceDatabase PerformanceDatabase = new PerformanceDatabase();
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    return;
                }

                if (commandLine != string.Empty)
                {
                    var result = ParseCommandLine(commandLine);
                    Console.WriteLine(result);
                }
            }
        }

        private static string ParseCommandLine(string commandLine)
        {
            string[] commandParts = commandLine.Split(new[] {'(', ',', ')'}, StringSplitOptions.RemoveEmptyEntries);
            string command = commandParts[0];
            string[] commandParameters = commandParts.Skip(1).Select(p => p.Trim()).ToArray();
            string commandResult = null;
            try
            {
                switch (command)
                {
                    case "AddTheatre":
                        commandResult = ExecuteAddTheatreCommand(commandParameters);
                        break;
                    case "PrintAllTheatres":
                        commandResult = ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        commandResult = ExecuteAddPerformanceCommand(commandParameters);
                        break;
                    case "PrintAllPerformances":
                        commandResult = ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        commandResult = ExecutePrintPerformances(commandParameters);
                        break;
                    default:
                        commandResult = Constants.InvalidCommandMessage;
                        break;
                }
                return commandResult;
            }
            catch (Exception ex)
            {
                return Constants.ErrorPrefix + ex.Message;
            }
        }

        private static string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[0];
            PerformanceDatabase.AddTheatre(theatreName);
            return Constants.TheatreAddedMessage;
        }

        public static string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = PerformanceDatabase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new List<string>();
                foreach (var theatre in PerformanceDatabase.ListTheatres())
                {
                    resultTheatres.Add(theatre);
                }

                return String.Join(", ", resultTheatres);
            }

            return Constants.NoTheatresMessage;
        }

        public static string ExecuteAddPerformanceCommand(string[] parameters)
        {
            string theatre = parameters[0];
            string title = parameters[1];
            DateTime startDate = DateTime.ParseExact(parameters[2], Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);
            PerformanceDatabase.AddPerformance(theatre, title, startDate, duration, price);
            return Constants.PerformanceAddedMessage;
        }

        public static string ExecutePrintAllPerformancesCommand()
        {
            var performancesCount = PerformanceDatabase.ListAllPerformances().Count();
            if (performancesCount > 0)
            {
                var performances = PerformanceDatabase
                    .ListAllPerformances()
                    .OrderBy(p => p.Theatre)
                    .ThenBy(p => p.Date)
                    .Select(p => string.Format(
                        "({0}, {1}, {2})", p.Title, p.Theatre, p.Date.ToString(Constants.DateTimeFormat)))
                    .ToList();

                return String.Join(", ", performances);
            }

            return Constants.NoPerformancesMessage;
        }

        public static string ExecutePrintPerformances(string[] parameters)
        {
            var theatre = parameters[0]; 
            var performancesCount = PerformanceDatabase.ListPerformances(theatre).Count();
            if (performancesCount > 0)
            {
                var performances = PerformanceDatabase
                    .ListPerformances(theatre)
                    .OrderBy(p => p.Date)
                    .Select(p => string.Format(
                        "({0}, {1})", p.Title, p.Date.ToString(Constants.DateTimeFormat)))
                    .ToList();

                return String.Join(", ", performances);
            }

            return Constants.NoPerformancesMessage;

        }
    }
}
