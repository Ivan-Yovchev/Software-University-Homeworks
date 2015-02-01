using System;

class Student : Human
{
    private string facultyNumber;

    public Student (string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Faculty number cannot be null or empty");
            }
            else if (value.Length < 5 || value.Length > 10)
            {
                throw new FormatException("Faculty number must contain form 5 to 10 characters");
            }
            else
            {
                this.facultyNumber = value;
            }
        }
    }

    public override string ToString()
    {
        return base.ToString() + ", Faculty Number: " + this.facultyNumber;
    }
}
