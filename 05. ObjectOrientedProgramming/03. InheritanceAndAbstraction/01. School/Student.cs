using System;
using System.Collections.Generic;

class Student : Person
{
    private string classNumber;
    private static List<string> takenNumbers;
    static Student()
    {
        Student.takenNumbers = new List<string>();
    }

    public Student(string name, string classNumber, string details = null)
        : base(name, details)
    {
        this.ClassNumber = classNumber;
    }

    public string ClassNumber
    {
        get { return this.classNumber; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("The class number must be a non-empty unique string");
            }
            else if (Student.takenNumbers.Contains(value))
            {
                throw new ArgumentException("This class number{" + value +"} is already taken");
            }
            else
            {
                this.classNumber = value;
                Student.takenNumbers.Add(value);
            }
        }
    }

    public override string ToString()
    {
        string result = string.Format("Name: {0}, №{1}", base.Name, this.classNumber);
        if (base.Details != null)
        {
            result += ", Details: " + base.Details;
        }

        return result;
    }

}
