using System;

class StringsAndObjects
{
    static void Main(string[] args)
    {
        string Hello = "Hello";
        string World = "World";
        object Concatenation = Hello + " " + World;
        string Sentence = (string)Concatenation;
        Console.WriteLine(Sentence);
    }
}

