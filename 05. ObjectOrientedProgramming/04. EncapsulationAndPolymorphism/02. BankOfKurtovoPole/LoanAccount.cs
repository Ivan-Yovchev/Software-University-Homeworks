using System;

class LoanAccount : BaseAccount, IAccount, IDepositable
{

    public LoanAccount(Customer customer, decimal balance, double interestRate)
        : base(customer, balance, interestRate)
    {
    }

    public override decimal CalculateInterest(int months)
    {
        decimal interest = 0;

        if (base.Customer == Customer.Individual)
        {
            if (months <= 3)
            {
                interest = base.Balance;
            }
            else
            {
                interest = base.CalculateInterest(months - 3);
            }
        }
        else if (base.Customer == Customer.Company)
        {
            if (months <= 2)
            {
                interest = base.Balance;
            }
            else
            {
                interest = base.CalculateInterest(months - 2);
            }
        }

        return interest;
    }
}
