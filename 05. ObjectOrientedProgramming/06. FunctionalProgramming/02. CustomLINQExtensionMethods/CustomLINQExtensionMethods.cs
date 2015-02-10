using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CustomLINQExtensionMethods
{
    static void Main(string[] args)
    {
        IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

        var whereNotNumbers = numbers.WhereNot(num => num <= 4);
        Console.WriteLine(string.Join(", ", whereNotNumbers));

        var repeatedNumbers = numbers.Repeat(5);
        Console.WriteLine(string.Join(", ", repeatedNumbers));

        IEnumerable<string> stringItems = new List<string>() { "ala", "bala", "nica", "turska", "panica" };
        IEnumerable<string> suffixes = new List<string>() { "ala", "ka" };
        Console.WriteLine(string.Join(", ", stringItems.WhereEndsWith(suffixes)));
    }
}
