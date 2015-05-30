namespace Theatre.Exceptions
{
    using System;

    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string message)
            : base(message)
        {

        }
    }
}
