using System;

class Teacher : Person
{
    private Discipline[] disciplines;

    public Teacher(string name, Discipline[] disciplines, string details = null)
        : base(name, details)
    {
        this.Disciplines = disciplines;
    }

    public Discipline[] Disciplines
    {
        get { return this.disciplines; }
        set { this.disciplines = value; }
    }

    public override string ToString()
    {
        string result = string.Format("Teacher name: {0}\n\n", base.Name);
        foreach (var discipline in disciplines)
        {
            result += discipline.ToString() + "\n\n";
        }

        if (base.Details != null)
        {
            result += string.Format("Details about teacher: {0}", base.Details);
        }

        return result;

    }

}
