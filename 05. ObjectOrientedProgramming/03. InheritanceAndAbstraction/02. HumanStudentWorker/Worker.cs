using System;

class Worker : Human
{
    private decimal weekSalary;
    private float workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, float workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set { this.weekSalary = value; }
    }

    public float WorkHoursPerDay 
    {
        get { return this.workHoursPerDay; }
        set { this.workHoursPerDay = value; }
    }

    public decimal MoneyPerHour()
    {
        return (this.weekSalary / 5) / (decimal)this.workHoursPerDay;
    }

    public override string ToString()
    {
        return base.ToString() + string.Format(", Weekly Salary: {0:N2}, Daily Work Hours: {0:N2}", this.WeekSalary, this.WorkHoursPerDay);
    }

}
