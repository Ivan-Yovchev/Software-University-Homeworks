using System;

class MainProgram
{
    static void Main(string[] args)
    {
        ElementBuilder div = new ElementBuilder("div");
        div.AddAtribute("id", "page");
        div.AddAtribute("class", "big");
        div.AddContent("<p>Hello</p>");
        Console.WriteLine(div * 2);

        var test = HTMLDispatcher.CreateImage("smiley.gif", "Smiley face", "Smiling :)");
        Console.WriteLine(test);

        test = HTMLDispatcher.CreateURL("http://www.w3schools.com", "Click to visit site!", "Visit W3Schools.com!");
        Console.WriteLine(test);

        test = HTMLDispatcher.CreateInput("submit", "SubmitForm", "Submit");
        Console.WriteLine(test);
    }
}
