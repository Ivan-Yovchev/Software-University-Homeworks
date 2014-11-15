using System;

class LongestWordInAText
{
    static void Main(string[] args)
    {
        string[] text = Console.ReadLine().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

        string longest = "";
        for (int i = 0; i < text.Length; i++)
        {
            if(text[i].Length > longest.Length)
            {
                longest = text[i];
            }
        }

        Console.WriteLine("The longest word in the text is: {0}",longest);
    }
}

