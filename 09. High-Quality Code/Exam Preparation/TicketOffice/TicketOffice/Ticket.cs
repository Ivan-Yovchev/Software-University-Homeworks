namespace TicketOffice
{
    using System;

    public abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(string from, string to, DateTime dateAndTime, decimal price)
        {
            this.From = from;
            this.To = to;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public abstract TicketType Type { get; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime DateAndTime { get; set; }

        public decimal Price { get; set; }

        public abstract string UniqueKey { get; }

        public override string ToString()
        {
            string result = String.Format(
                "[{0}|{1}|{2}]",
                this.DateAndTime.ToString(Constants.DateTimeFormat),
                this.Type.ToString().ToLower(),
                String.Format(Constants.NumberFormat, this.Price));

            return result;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int resultOfCompare = this.DateAndTime.CompareTo(otherTicket.DateAndTime); 
            if (resultOfCompare == 0)
            {
                resultOfCompare = ((int) this.Type).CompareTo((int) otherTicket.Type);
            } 
            
            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Price.CompareTo(otherTicket.Price);
            } 
            
            return resultOfCompare;
        }
    }
}
