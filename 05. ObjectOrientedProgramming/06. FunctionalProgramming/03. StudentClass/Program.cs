using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        students.Add(new Student(
            "Petar",
            "Petrov",
            23,
            "800014",
            "+359888456123",
            "alabala@dir.bg",
            2,
            "Plovdiv",
            new List<int>() { 2, 3, 4, 4, 6, 5, 6, 6 }));

        students.Add(new Student(
            "Emil",
            "Emilov",
            33,
            "850014",
            "+359 2555623",
            "alabala@abv.bg",
            1,
            "Plovdiv",
            new List<int>() { 6, 6, 6, 6, 6, 5, 6, 6 }));

        students.Add(new Student(
            "Zdravko",
            "Ivanov",
            17,
            "734015",
            "+35942456123",
            "zizo@dir.bg",
            2,
            "Sofia",
            new List<int>() { 2, 3, 4, 6, 6, 4, 5, 5, 5, 3, 2 }));

        students.Add(new Student(
            "Dinko",
            "Dinev",
            26,
            "023016",
            "+359888457873",
            "didi@softuni.bg",
            1,
            "Sofia",
            null));

        students.Add(new Student(
            "Samuil",
            "Asparuhov",
            19,
            "800014",
            "+359888456123",
            "alabala@dir.bg",
            2,
            "Sofia",
            new List<int>() { 2, 3, 4, 4, 6, 5, 6, 6 }));

        students.Add(new Student(
            "Gosho",
            "Peshev",
            33,
            "851014",
            "+359888555623",
            "alabala@abv.bg",
            1,
            "Ruse",
            new List<int>() { 6, 6, 6, 6, 6, 5, 6, 6 }));

        students.Add(new Student(
            "Damyan",
            "Damyanov",
            17,
            "734115",
            "+35942456123",
            "zizo@dir.bg",
            2,
            "Ruse",
            new List<int>() { 2, 3, 4, 6, 6, 4, 5, 5, 5, 3, 2 }));

        students.Add(new Student(
            "Tsonko",
            "Gochev",
            26,
            "023116",
            "+359888457873",
            "didi@softuni.bg",
            1,
            "Ruse",
            new List<int>() { 2, 3, 4, 2, 2, 2, 5, 6, 6 }));

        var groupByFirstName = students
            .Where(student => student.GroupNumber == 2)
            .OrderBy(student => student.FirstName);

        foreach (var student in groupByFirstName)
        {
            Console.WriteLine(student);
        }

        var firstBeforeLastName = students
            .Where(student => student.FirstName.CompareTo(student.LastName) < 0);

        foreach (var student in firstBeforeLastName)
        {
            Console.WriteLine(student);
        }

        var studentsByAge = students
            .Where(student => student.Age >= 18 || student.Age <= 24)
            .Select(student => string.Format("{0} {1} Age: {2}", student.FirstName, student.LastName, student.Age));

        foreach (var student in studentsByAge)
        {
            Console.WriteLine(student);
        }

        var sortStudents = students
            .OrderByDescending(student => student.FirstName)
            .ThenByDescending(student => student.LastName);

        foreach (var student in sortStudents)
        {
            Console.WriteLine(student);
        }

        var emailDomain = students
            .Where(student => student.Email.Contains("@abv.bg"));

        foreach (var student in emailDomain)
        {
            Console.WriteLine(student);
        }

        var phonesFilter = students
            .Where(student => student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2"));

        foreach (var student in phonesFilter)
        {
            Console.WriteLine(student);
        }

        var excellentStudents = students
            .Where(student => student.Marks
                .Any(mark => mark == 6))
                .Select(student => new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks });

        foreach (var student in excellentStudents)
        {
            Console.WriteLine(string.Format("{0}, Marks: {1}", student.FullName, string.Join(", ", student.Marks)));
        }

        var weakStudents = students
            .Where(student => student.Marks.Where(mark => mark == 2).Count() == 2);

        foreach (var student in weakStudents)
        {
            Console.WriteLine(student);
        }

        var enrolledStudents = students
            .Where(student => student.FacultyNumber.EndsWith("14"))
            .Select(student => student.Marks);

        foreach (var marks in enrolledStudents)
        {
            Console.WriteLine(string.Join(", ", marks));
        }

        var byGroups = from student in students
                       group student by student.GroupName into gr
                       select new { GroupName = gr.Key, students = gr.ToList() };

        foreach (var item in byGroups)
        {
            Console.WriteLine(item.GroupName);
            Console.WriteLine(string.Join("\n\t", item.students));
        }

    }
}
