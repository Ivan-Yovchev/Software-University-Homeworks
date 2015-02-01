using System;
using System.Collections.Generic;
using System.Linq;

class AnimalTesting
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Animal jaba = new Frog("baba jaba", 1, Gender.Female);
        Animal kekerica = new Frog("kekerica", 3, Gender.Female);

        Animal sharo = new Dog("sharo", 3, Gender.Male);
        Animal sara = new Dog("sara", 2, Gender.Female);
        Animal oldy = new Dog("oldy", 12, Gender.Male);

        Animal puhi = new Kitten("puhi", 2);
        Animal tommy = new TomCat("tommy", 4);
        Animal mouseKiller = new Cat("mousy", 5, Gender.Male);

        List<Animal> animals = new List<Animal>()
            {
                jaba,
                kekerica,
                sharo,
                sara,
                puhi,
                tommy,
                mouseKiller,
                oldy
            };
        var groupedAnimals = from animal in animals
                             group animal by (animal is Cat) ? typeof(Cat) : animal.GetType() into gr
                             select new { GroupName = gr.Key, AverageAge = gr.ToList().Average(an => an.Age) };

        foreach (var animal in groupedAnimals)
        {
            Console.WriteLine("{0} - average age: {1:N2}", animal.GroupName.Name, animal.AverageAge);
        }

    }
}
