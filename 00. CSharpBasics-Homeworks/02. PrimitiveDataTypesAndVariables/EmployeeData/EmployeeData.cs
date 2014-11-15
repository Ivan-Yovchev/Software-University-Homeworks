using System;

class EmployeeData
{
    static void Main(string[] args)
    {
        string name = "Georgi";
        string surname = "Ivanov";
        byte age = 31;
        char gender = 'm';
        long ID = 8306112507;
        string number = "27560007665427569999";

        Console.WriteLine("Name: " + name + " " + surname);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Gender: " + gender);
        Console.WriteLine("Personal ID number: " + ID);
        Console.WriteLine("Unique employee number: " + number);
    }
}

