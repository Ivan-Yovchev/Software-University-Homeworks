namespace TravelAgency
{
    using System;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dateTime, decimal regularPrice, decimal studentPrice)
            : base(from, to, dateTime, regularPrice)
        {
            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string from, string to, DateTime dateTime)
            : this(from, to, dateTime, 0, 0)
        {
        }

        public decimal StudentPrice { get; set; }

        public override string UniqueKey
        {
            get { return string.Format("{0};;{1};{2};{3};", this.Type, this.From, this.To, this.DateTime); }
        }

        public override TicketType Type
        {
            get { return TicketType.Train; }
        }
    }
}
