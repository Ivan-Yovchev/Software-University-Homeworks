using System;

class Dog : Animal, ISound
{
    public Dog(string name, int age, Gender gender)
        : base (name, age, gender)
    {

    }

    public void ProduceSound()
    {
        Console.WriteLine("I say wof wof!");
    }
}
