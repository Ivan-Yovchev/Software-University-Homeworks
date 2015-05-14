namespace TicketOffice
{
    using System;

    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string from, string to, string airline, DateTime dateAndTime, decimal price)
            : base(from, to, dateAndTime, price)
        {
            this.FlightNumber = flightNumber;
            this.Airline = airline;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, default(DateTime), 0)
        {
        }

        public string FlightNumber { get; set; }

        public string Airline { get; set; }

        public override TicketType Type
        {
            get { return TicketType.Flight; }
        }

        public override string UniqueKey
        {
            get { return String.Format("{0};;{1}", this.Type, this.FlightNumber); }
        }
    }
}
