using System;
using WcfServiceCalculatorConsoleClient.DistanceService;

namespace WcfServiceCalculatorConsoleClient
{
    class ServiceCalculatorConsoleClient
    {
        static void Main()
        {
            CalculatorClient calc = new CalculatorClient();
            var distance = calc.CalcDistance(new Point(10, 10), new Point(15, 15));
            Console.WriteLine(distance);
        }
    }
}
