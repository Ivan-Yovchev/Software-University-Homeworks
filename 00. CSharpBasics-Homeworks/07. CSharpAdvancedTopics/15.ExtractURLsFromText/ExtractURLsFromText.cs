using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractURLsFromText
{
    static void Main(string[] args)
    {
        Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        string rawString = Console.ReadLine();

        Console.WriteLine("URLs: ");
        foreach (Match m in linkParser.Matches(rawString))
        {
            Console.WriteLine(m.Value);
        }
    }
}

