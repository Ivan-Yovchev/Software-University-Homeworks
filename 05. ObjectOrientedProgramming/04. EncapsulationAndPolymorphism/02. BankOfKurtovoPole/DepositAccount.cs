using System;

public class DepositAccount : BaseAccount, IWithdrawable, IAccount, IDepositable
{

    public DepositAccount(Customer customer, decimal balance, double interestRate)
        : base(customer, balance, interestRate)
    {
    }

    public override decimal CalculateInterest(int months)
    {
        decimal interest;

        if (base.Balance >= 0 && base.Balance < 1000)
        {
            interest = base.Balance;
        }
        else
        {
            interest = base.CalculateInterest(months);
        }

        return interest;
    }

    public decimal WithDrawMoney(decimal money)
    {
        base.Balance -= money;
        return base.Balance;
    }
}
