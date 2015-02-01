using System;

public interface IAccount
{
    Customer Customer { get; set; }
    decimal Balance { get; set; }
    double InterestRate { get; set; }
    decimal CalculateInterest(int months);
}
