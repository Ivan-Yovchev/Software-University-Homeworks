namespace TravelAgency
{
    using System;
    using System.Globalization;
    using System.Threading;

    class TravelAgencyMain
    {
        private static ITicketCatalog ticketCatalog = new TicketCatalog();

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                if (line != string.Empty)
                {
                    string commandResult = ProcessCommand(line);
                    Console.WriteLine(commandResult);
                }
            }
        }

        private static string ProcessCommand(string line)
        {
            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return Constants.Invalidcommand;
            }

            string command = line.Substring(0, firstSpaceIndex);
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            string commandResult;
            switch (command)
            {
                case "AddAir":
                    commandResult = ProccessAddAirCommand(parameters);
                    break;
                case "DeleteAir":
                    commandResult = ProccessDeleteAirCommand(parameters);
                    break;
                case "AddTrain":
                    commandResult = ProccessAddTrainCommand(parameters);
                    break;
                case "DeleteTrain":
                    commandResult = ProccessDeleteTrainCommand(parameters);
                    break;
                case "AddBus":
                    commandResult = ProccessAddBusCommand(parameters);
                    break;
                case "DeleteBus":
                    commandResult = ProccessDeleteBusCommand(parameters);
                    break;
                case "FindTickets":
                    commandResult = ProccessFindTicketsCommand(parameters);
                    break;
                case "FindTicketsInInterval":
                    commandResult = ProccessFindTicketsInIntervalCommand(parameters);
                    break;
                default:
                    commandResult = Constants.NotFoundMsg;
                    break;
            }

            return commandResult;
        }

        private static string ProccessFindTicketsInIntervalCommand(string[] parameters)
        {
            DateTime startDateTime = ParseDateTime(parameters[0]);
            DateTime endDateTime = ParseDateTime(parameters[1]);
            string commandResult = ticketCatalog.FindTicketsInInterval(startDateTime, endDateTime);
            return commandResult;
        }

        private static string ProccessFindTicketsCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string commandResult = ticketCatalog.FindTickets(from, to);
            return commandResult;
        }

        private static string ProccessDeleteBusCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string travelCompany = parameters[2];
            DateTime dateTime = ParseDateTime(parameters[3]);
            string commandResult = ticketCatalog.DeleteBusTicket(from, to, travelCompany, dateTime);
            return commandResult;
        }

        private static string ProccessAddBusCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string travelCompany = parameters[2];
            DateTime dateTime = ParseDateTime(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);
            var commandResult = ticketCatalog.AddBusTicket(from, to, travelCompany, dateTime, price);
            return commandResult;
        }

        private static string ProccessDeleteTrainCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateTime = ParseDateTime(parameters[2]);
            string commandResult = ticketCatalog.DeleteTrainTicket(from, to, dateTime);
            return commandResult;
        }

        private static string ProccessAddTrainCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateTime = ParseDateTime(parameters[2]);
            decimal regularPrice = decimal.Parse(parameters[3]);
            decimal studentPrice = decimal.Parse(parameters[4]);
            string commandResult = ticketCatalog.AddTrainTicket(from, to, dateTime, regularPrice, studentPrice);
            return commandResult;
        }

        private static string ProccessDeleteAirCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string commandResult = ticketCatalog.DeleteAirTicket(flightNumber);
            return commandResult;
        }

        private static string ProccessAddAirCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string from = parameters[1];
            string to = parameters[2];
            string airline = parameters[3];
            DateTime dateTime = ParseDateTime(parameters[4]);
            decimal price = decimal.Parse(parameters[5]);
            string commandResult = ticketCatalog.AddAirTicket(flightNumber, from, to, airline, dateTime, price);
            return commandResult;
        }

        private static DateTime ParseDateTime(string timeString)
        {
            DateTime result = DateTime.ParseExact(timeString, Constants.DateTimeFormat,
                CultureInfo.InvariantCulture);

            return result;
        }
    }
}
