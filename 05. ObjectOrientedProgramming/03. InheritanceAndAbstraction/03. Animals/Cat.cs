using System;

class Cat : Animal, ISound
{
    public Cat(string name, int age, Gender gender)
        : base(name, age, gender)
    {

    }

    public void ProduceSound()
    {
        Console.WriteLine("I say myauu!");
    }
}
