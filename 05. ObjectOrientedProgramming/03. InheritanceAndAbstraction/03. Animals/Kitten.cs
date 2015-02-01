using System;

class Kitten : Cat
{
    public Kitten(string name, int age)
        : base(name, age, Gender.Female)
    {

    }

    public void ProduceSound()
    {
        Console.WriteLine("I say myauu!");
    }
}
