using System;
using System.Collections.Generic;
using System.Linq;

class CustomerTest
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Payment firstPayment = new Payment("Laptop", 1859m);
        Payment secondPayment = new Payment("Mouse", 15.20m);

        Customer firstCustomer = 
            new Customer("Pesho", 
            "Ivanov", 
            "Peshev", 
            "9601256724", 
            "Ulitsa Voinishka, grad Varna", 
            "0896732389", 
            "peshkata@abv.bg", 
            new List<Payment>() { firstPayment, secondPayment }, 
            CustomerType.Regular);

        //create a deep copy
        Customer secondCustomer = (Customer)firstCustomer.Clone();

        Console.WriteLine(secondCustomer == firstCustomer); // True

        secondCustomer.FirstName = "Misho";
        Console.WriteLine(secondCustomer != firstCustomer); // True

        Console.WriteLine(firstCustomer.CompareTo(secondCustomer)); // 1

        Console.WriteLine(firstCustomer);
    }
}
