using System;

public class Student
{
    private string name;
    private int age;

    public Student(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

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
                throw new ArgumentException("Name cannot be null or empty");
            }

            this.OnPropertyChanged(new PropertyChangedEventArgs("Name", this.name, value));
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }

        set
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs("Age", this.Age.ToString(), value.ToString()));
            this.age = value;
        }
    }

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (null != this.PropertyChanged)
        {
            this.PropertyChanged(this, e);
        }
    }
}
