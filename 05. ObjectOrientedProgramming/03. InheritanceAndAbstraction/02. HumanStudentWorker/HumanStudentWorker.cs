using System;
using System.Collections.Generic;
using System.Linq;

class HumanStudentWorker
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        List<Student> students = new List<Student>()
        {
            new Student("Pesho", "Peshev", "123GDS"),
            new Student("Gosho", "Goshev", "GSHS12345"),
            new Student("Ivan", "Ivanov", "JAJSD89"),
            new Student("Misho", "Mishev", "7273HD"),
            new Student("Bai", "Petio", "JU88SD"),
            new Student("Mitko", "Mitev", "33KDU"),
            new Student("Petq", "Petrova", "LA467K6"),
            new Student("Mariika", "Ilieva", "DK0992"),
            new Student("Radi", "Radoslavov", "J8J8LD9"),
            new Student("Aleksandar", "Kolev", "LASDP3")
        };

        var sortedStudents = students.OrderBy(st => st.FacultyNumber);
        Console.WriteLine("Sorted Students: ");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine(student);
        }

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Indiana", "Jones", 282m, 8f),
            new Worker("Bai", "Ganio", 382m, 6.5f),
            new Worker("Don", "Kihot", 243m, 4.75f),
            new Worker("Mecho", "Puh", 152m, 2.75f),
            new Worker("Chervenata", "Shapchica", 182m, 5.5f),
            new Worker("Sherloc", "Holmes", 242m, 7.5f),
            new Worker("Moby", "Dick", 482m, 6f),
            new Worker("Jay", "Gatsby", 578m, 9f),
            new Worker("Victor", "Frankenstein", 439m, 8f),
            new Worker("Count", "Dracula", 658m, 9f)
        };

        var sortedWorkers = workers.OrderByDescending(wr => wr.MoneyPerHour());
        Console.WriteLine("\nSorted Workers: ");
        foreach (var worker in sortedWorkers)
        {
            Console.WriteLine(string.Format("Money Per Hour: {0:N2}, ", worker.MoneyPerHour()) + worker);
        }

        List<Human> merjedHumans = new List<Human>();
        merjedHumans.AddRange(students);
        merjedHumans.AddRange(workers);

        var sortedHumans = merjedHumans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
        Console.WriteLine("\nSorted Humans: ");
        foreach (var human in sortedHumans)
        {
            Console.WriteLine(human);
        }

    }
}
