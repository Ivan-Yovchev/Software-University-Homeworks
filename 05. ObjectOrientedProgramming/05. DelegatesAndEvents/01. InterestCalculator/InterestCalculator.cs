using System;

public delegate decimal CalculateInterest(decimal money, double interest, int years);

public class InterestCalculator
{
    private decimal money;
    private double interest;
    private int years;
    private decimal result;

    public InterestCalculator(decimal money, double interest, int years, CalculateInterest type)
    {
        this.Money = money;
        this.Interest = interest;
        this.Years = years;
        this.result = type(money, interest, years);
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Sum cannot be a zero or negative number");
            }
            else
            {
                this.money = value;
            }
        }
    }

    public double Interest
    {
        get
        {
            return this.interest;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Interest cannot be negative");
            }
            else
            {
                this.interest = value;
            }
        }
    }

    public int Years
    {
        get
        {
            return this.years;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Years cannot be a negative number");
            }
            else
            {
                this.years = value;
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0:N4}", this.result);
    }

}
