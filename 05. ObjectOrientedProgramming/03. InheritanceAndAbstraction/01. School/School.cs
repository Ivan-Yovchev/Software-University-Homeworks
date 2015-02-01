using System;

class School
{
    static void Main(string[] args)
    {
        Student[] students1 = new Student[]
        {
            new Student("Pesho", "123SB4", "Otlichnik"),
            new Student("Mariq", "123SB8"),
            new Student("Gosho", "132SB4"),
            new Student("Penka", "M33SB4", "Programist")
        };

        Student[] students2 = new Student[]
        {
            new Student("Pencho", "2K5SB4"),
            new Student("Bai Ganio", "MSJ45A"),
            new Student("Ali", "123456"),
            new Student("Strahil", "ABC4DU", "Karucar")
        };

        Discipline[] disArr = new Discipline[]
        {
            new Discipline("Matematika za Programisti", 21, students1, "Mnogo trudni zadachi"),
            new Discipline("Programirane za matematici", 3, students2, "Vnimanie Zyl Profesor")
        };

        Teacher tech1 = new Teacher("Bau Ivan", disArr, "Mnogo dobyr uchitel");
        Teacher tech2 = new Teacher("Baba Mimi", disArr, "Zlo Kuche");

        Console.WriteLine(tech1);

    }
}
