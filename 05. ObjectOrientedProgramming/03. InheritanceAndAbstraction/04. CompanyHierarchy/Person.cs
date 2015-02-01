using System;
using System.Collections.Generic;

public abstract class Person : IPerson
{
    private string id, firstName, lastName;

    private static List<string> uniqueIDs;

    static Person()
    {
        uniqueIDs = new List<string>();
    }

    public Person(string id, string firstName, string lastName)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string ID
    {
        get { return this.id; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The ID cannot be null or empty");
            }
            else if (uniqueIDs.Contains(value))
            {
                throw new ArgumentException("ID is already taken");
            }
            else
            {
                this.id = value;
                Person.uniqueIDs.Add(value);
            }
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("First name cannot be null or empty");
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
                throw new ArgumentNullException("Last name cannot be null or empty");
            }
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        return string.Format("Name: {0} {1}, ID: {2}", this.FirstName, this.LastName, this.ID);
    }
}
