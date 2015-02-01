using System;
using System.Collections.Generic;

class SalesEmployee : RegularEmployee, ISalesEmployee
{

    private List<ISale> sales;

    public SalesEmployee(string id, string firstName, string lastName, decimal salary, Department department, List<ISale> sales)
        : base(id, firstName, lastName, salary, department)
    {
        this.Sales = sales;
    }

    public List<ISale> Sales
    {
        get { return this.sales; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Sales cannot be null");
            }
            this.sales = value;
        }
    }

    public override string ToString()
    {
        string baseStr = base.ToString() + "\n\n";
        string salesStr = "";
        foreach (var sale in sales)
        {
            salesStr += sale.ToString() + "\n";
        }

        return baseStr + "Sales:\n" + salesStr;
    }

}
