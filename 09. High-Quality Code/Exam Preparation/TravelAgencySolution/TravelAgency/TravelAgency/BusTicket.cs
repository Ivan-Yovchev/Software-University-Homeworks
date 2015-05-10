namespace TravelAgency
{
    using System;

    class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
            : base(from, to, dateTime, price)
        {
            this.TravelCompany = travelCompany;
        }

        public BusTicket(string from, string to, string travelCompany, DateTime dateTime)
            :this(from, to, travelCompany, dateTime, 0)
        {
        }

        public string TravelCompany { get; set; }

        public override string UniqueKey
        {
            get { return string.Format("{0};;{1};{2};{3};{4};", this.Type, this.From, this.To, this.TravelCompany, this.DateTime); }
        }
        public override TicketType Type
        {
            get { return TicketType.Bus; }
        }
    }
}
