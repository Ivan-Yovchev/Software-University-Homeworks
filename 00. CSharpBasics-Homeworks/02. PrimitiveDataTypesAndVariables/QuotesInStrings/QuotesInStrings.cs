using System;

class QuotesInStrings
{
    static void Main(string[] args)
    {
        string Quoted = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("Quoted string: " + Quoted);
        string NotQuoted = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine("Not quoted string: " + NotQuoted);
    }
}

