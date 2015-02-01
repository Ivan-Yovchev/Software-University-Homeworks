using System;

public abstract class BaseAccount : IAccount, IDepositable
{
    private Customer customer;
    private decimal balance;
    private double interestRate;

    public BaseAccount(Customer customer, decimal balance, double interestRate)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    public Customer Customer
    {
        get
        {
            return this.customer;
        }
        set
        {
            this.customer = value;
        }
    }

    public decimal Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            this.balance = value;
        }
    }

    public double InterestRate
    {
        get
        {
            return this.interestRate;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Interest cannot be zero or negative");
            }
            this.interestRate = value;
        }
    }

    public virtual decimal CalculateInterest(int months)
    {
        return this.Balance * (1 + ((decimal)this.InterestRate / 100) * (decimal)months);
    }

    public decimal DepositMoney(decimal money)
    {
        this.balance += money;
        return this.balance;
    }
}
