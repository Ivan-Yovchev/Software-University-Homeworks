using System;

class Person : IDetail
{
    private string name;
    private string details;

    public Person(string name, string details = null)
    {
        this.Name = name;
        this.Details = details;
    }

    public string Name 
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The name must be a non-empty string");
            }
            this.name = value;
        }
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
        string result = "Name: " + this.name;
        if (this.details != null)
        {
            result += ", Details: " + this.details;
        }

        return result;

    }

}
