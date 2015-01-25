using System;

class Person
{
    private int age;
    private string name;
    private string email;

    public Person(string name, int age, string email)
    {
        this.Age = age;
        this.Name = name;
        this.Email = email;
    }

    public Person(string name, int age) : this(name, age, null)
    {
    }

    public int Age 
    {
        get
        {
            return this.age;
        }
        set
        {
            if ((value > 100) || (value < 1))
            {
                throw new ArgumentOutOfRangeException("Age must be in the range [1...100]");
            }
            this.age = value;
        }
    }
    public string Name 
    { 
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            this.name = value;
        }
    }

    public string Email 
    {
        get 
        {
            return this.email;
        }
        set 
        {
            if (value == null || value.Contains("@"))
            {
                this.email = value; 
            }
            else
            {
                throw new Exception("Email must be null or non-empty containing the symbol \"@\"");
            }
            
        }
    }

    public override string ToString()
    {
        string result = "Name: " + this.name + "\nAge: " + this.age;
        if (this.email != null)
        {
            result += "\nEmail: " + this.email;
        }

        return result;

    }

}

class Persons
{
    static void Main(string[] args)
    {
        Person ivan = new Person("Ivan", 17);
        Console.WriteLine(ivan);
    }
}
