using System;
using System.Net;

namespace WebApplicationRestConsoleClient
{
    class RestConsoleClient
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var response = client
                    .UploadString("http://localhost:2218/distance?startX=10&startY=10&endX=15&endY=15", 
                    "POST", 
                    string.Empty);
                Console.WriteLine(response);
            }
        }
    }
}
