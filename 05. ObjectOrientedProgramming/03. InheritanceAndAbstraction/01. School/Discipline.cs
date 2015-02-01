using System;

class Discipline : IDetail
{
    private string name, details;
    private int numberOfLectures;
    private Student[] students;

    public Discipline(string name, int numberOfLectures, Student[] students, string details = null)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.Students = students;
        this.Details = details;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The name of the Discipline must be a non-empty string");
            }
            this.name = value;
        }
    }

    public int NumberOfLectures
    {
        get { return this.numberOfLectures; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("The number of lectures must be a positive non-zero number");
            }
            this.numberOfLectures = value;
        }
    }

    public Student[] Students
    {
        get { return this.students; }
        set { this.students = value; }
    }

    public string Details
    {
        get { return this.details; }
        set
        {
            if (value == "")
            {
                throw new ArgumentException("Details must be a non-empty string");
            }
            this.details = value;
        }
    }

    public override string ToString()
    {
        string formatStudents = "";
        for (int i = 0; i < students.Length; i++)
        {
            if (i == 0)
            {
                formatStudents += students[i].Name + " №" + students[i].ClassNumber;
            }
            else
            {
                formatStudents += ", " + students[i].Name + " №" + students[i].ClassNumber;
            }
        }

        string result = string.Format("Discipline Name: {0}\nNumber of Lectures: {1}\nStudents: [{2}]\n", this.name, this.numberOfLectures, formatStudents);

        if (this.details != null)
        {
            result += "Details: " + this.details;
        }

        return result;
        
    }

}
