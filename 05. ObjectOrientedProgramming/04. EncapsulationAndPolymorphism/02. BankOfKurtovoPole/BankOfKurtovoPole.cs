using System;
using System.Collections.Generic;

class BankOfKurtovoPole
{
    static void Main(string[] args)
    {
        Customer gosho = Customer.Individual;
        Customer someCompany = Customer.Company;

        BaseAccount mortgageAccInd = new MortgageAccount(gosho, 1024m, 5.3);
        BaseAccount mortgageAccComp = new MortgageAccount(someCompany, 1024m, 5.3);
        BaseAccount loanAccInd = new LoanAccount(gosho, 1024m, 5.3);
        BaseAccount loanAccComp = new LoanAccount(someCompany, 1024m, 5.3);
        BaseAccount depositAccIndBig = new DepositAccount(gosho, 1024m, 5.3);
        BaseAccount depositAccIndSmall = new DepositAccount(gosho, 999m, 5.3);
        BaseAccount depositAccComp = new DepositAccount(someCompany, 11024m, 4.3);

        List<BaseAccount> accounts = new List<BaseAccount>()
            {
                mortgageAccInd,
                mortgageAccComp,
                loanAccInd,
                loanAccComp,
                depositAccIndBig,
                depositAccIndSmall,
                depositAccComp
            };

        foreach (var acc in accounts)
        {
            Console.WriteLine(
                "{5} {0,-15}: {1:N2}, {2:N2}, {3:N2}, {4:N2}",
                acc.GetType().Name,
                acc.CalculateInterest(2),
                acc.CalculateInterest(3),
                acc.CalculateInterest(10),
                acc.CalculateInterest(13),
                acc.Customer);
        }

    }
}
