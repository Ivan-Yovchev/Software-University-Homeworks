using System;

class BankAccountData
{
    static void Main(string[] args)
    {
        string Name = "Milena";
        string MiddleName = "Dimitrova";
        string LastName = "Stoqnova";
        double Money = 5489.23;
        string BankName = "City bank";
        string IBAN = "GB03 WEST 1334 5690 7654 33";
        long CardOne = 1234567891231234;
        long CardTwo = 1236784343575675;
        long CardThree = 4562325775634243;

        Console.WriteLine("Name: {0} {1} {2}",Name,MiddleName,LastName);
        Console.WriteLine("Money balance: {0}",Money);
        Console.WriteLine("Bank name: {0}",BankName);
        Console.WriteLine("IBAN: {0}", IBAN);
        Console.WriteLine("Credit card number: {0}",CardOne);
        Console.WriteLine("Credit card number: {0}", CardTwo);
        Console.WriteLine("Credit card number: {0}", CardThree);
    }
}

