namespace Theatre
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string title, DateTime date, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.Title = title;
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; private set; }
        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan Duration { get; private set; }
        public decimal Price { get; private set; }

        public override string ToString()
        {
            string result = string.Format(
                "Performance(Theatre: {0}, Title: {1}, Date: {2}, Duration: {3}, Price: {4})",
                this.Theatre,
                this.Title,
                this.Date.ToString(Constants.DateTimeFormat),
                this.Duration.ToString(Constants.TimeSpanFormat),
                this.Price.ToString(Constants.PriceFormat));
            return result;
        }

        public int CompareTo(Performance otherPerformance)
        {
            int compareResult = this.Date.CompareTo(otherPerformance.Date);
            return compareResult;
        }
    }
}
