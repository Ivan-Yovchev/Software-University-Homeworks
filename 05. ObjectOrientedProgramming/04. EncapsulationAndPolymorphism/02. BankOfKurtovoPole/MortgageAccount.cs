using System;

class MortgageAccount : BaseAccount, IAccount, IDepositable
{

    public MortgageAccount(Customer customer, decimal balance, double interestRate)
        : base(customer, balance, interestRate)
    {
    }

    public override decimal CalculateInterest(int months)
    {
        decimal interest = 0;

        if (base.Customer == Customer.Individual)
        {
            if (months <= 6)
            {
                interest = base.Balance;
            }
            else
            {
                interest = base.CalculateInterest(months - 6);
            }
        }
        else if (base.Customer == Customer.Company)
        {
            if (months <= 12)
            {
                base.InterestRate = base.InterestRate / 2;
                interest = base.CalculateInterest(12);
            }
            else
            {
                decimal tempMoney = base.Balance;

                base.InterestRate = base.InterestRate / 2;
                base.Balance = base.CalculateInterest(12);

                base.InterestRate = base.InterestRate * 2;
                interest = base.CalculateInterest(months - 12);

                base.Balance = tempMoney;
            }
        }

        return interest;
    }

}
