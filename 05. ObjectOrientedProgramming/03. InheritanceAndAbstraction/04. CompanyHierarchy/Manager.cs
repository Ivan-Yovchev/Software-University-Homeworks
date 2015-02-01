using System;
using System.Collections.Generic;

class Manager : Employee, IManager
{
    private List<Employee> employees;

    public Manager(string id, string firstName, string lastName, decimal salary, Department department, List<Employee> employees)
        : base(id, firstName, lastName, salary, department)
    {
        this.Employees = employees;
    }

    public List<Employee> Employees
    {
        get { return this.employees; }
        set 
        {
            if (value == null)
            {
                throw new ArgumentException("Employees cannot be null");
            }
            this.employees = value; 
        }
    }

    public override string ToString()
    {
        string baseString = base.ToString() + "\n\n";
        string employesString = "";
        foreach (var employee in employees)
        {
            employesString += employee.ToString() + "\n";
        }

        return baseString + "Employees Under Command:\n" + employesString;
    }
}
