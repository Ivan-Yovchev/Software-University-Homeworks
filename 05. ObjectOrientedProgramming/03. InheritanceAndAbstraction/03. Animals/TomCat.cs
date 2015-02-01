using System;

class TomCat : Cat
{
    public TomCat(string name, int age)
        : base(name, age, Gender.Male)
    {

    }

    public void ProduceSound()
    {
        Console.WriteLine("I say myauu!");
    }
}
