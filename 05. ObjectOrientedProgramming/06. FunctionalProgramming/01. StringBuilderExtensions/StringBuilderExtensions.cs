using System;
using System.Collections.Generic;
using System.Text;

class StringBuilderExtensions
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        StringBuilder test = new StringBuilder();
        test.Append("This sentance is a test!");
        Console.WriteLine(test.Substring(5, 8));

        test.RemoveText("TeSt");
        Console.WriteLine(test);

        IEnumerable<double> numbers = new List<double>()
        {
            23.56,
            1.7,
            39.0,
            238.781,
            1.1,
            76.8,
            2
        };

        test.AppendAll(numbers);
        Console.WriteLine(test);
    }
}
