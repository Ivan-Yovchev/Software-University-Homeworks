using System;

public abstract class Animal
{
    private string name;
    private int age;
    private Gender gender;

    public Animal(string name, int age, Gender gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The name cannot be null or empty");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The age cannot be a negative number");
            }
            this.age = value;
        }
    }

    public Gender Gender
    {
        get { return this.gender; }
        set { this.gender = value; }
    }

    public override string ToString()
    {
        return string.Format("Name: {0}, Age: {1}, Gender: {2}", this.Name, this.Age, this.Gender);
    }

}
