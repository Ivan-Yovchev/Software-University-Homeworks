namespace Theatre.Exceptions
{
    using System;

    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string message)
            : base(message)
        {
        }
    }
}
