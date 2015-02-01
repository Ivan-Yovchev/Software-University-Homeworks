using System;

abstract class Human
{
    private string firstName, lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName 
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("First Name must be a non-empty string");
            }
            this.firstName = value;
        }
    }
    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("First Name must be a non-empty string");
            }
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        return string.Format("Name: {0} {1}", this.FirstName, this.LastName);
    }

}
