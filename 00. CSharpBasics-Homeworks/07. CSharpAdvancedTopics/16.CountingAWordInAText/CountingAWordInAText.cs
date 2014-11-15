using System;
using System.Linq;
class CountingAWordInAText
{
    static void Main(string[] args)
    {
        Console.Write("Enter search word: ");
        string wordSearch = Console.ReadLine();
        Console.Write("Enter text: ");
        String text = Console.ReadLine();

        //Convert the string into an array of words 
        string[] source = text.Split(new char[] { '.', '?', '!', '@', '/', '\\', ' ', ';', ':', ',', '(', ')', '"', ' ' }, StringSplitOptions.None);

        // Create the query.  Use ToLowerInvariant to match "data" and "Data"  
        var matchQuery = from word in source
                         where word.ToLowerInvariant() == wordSearch.ToLowerInvariant()
                         select word;

        // Count the matches, which executes the query. 
        int wordCount = matchQuery.Count();
        Console.WriteLine("Number of times the word was found: " + wordCount);
    }
}

