using System;

class PrintCompanyInformation
{
    static void Main(string[] args)
    {
        // input
        Console.Write("Company name: ");
        string name = Console.ReadLine();
        Console.Write("Company address: ");
        string address = Console.ReadLine();
        Console.Write("Phone number: ");
        string number = Console.ReadLine();
        Console.Write("Fax number: ");
        string fax = Console.ReadLine();
        Console.Write("Web site: ");
        string site = Console.ReadLine();
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manger last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager age: ");
        string managerAge = Console.ReadLine();
        Console.Write("Manager phone: ");
        string managerPhone = Console.ReadLine();

        // output
        Console.WriteLine();
        Console.WriteLine(name);
        Console.WriteLine("Address: {0}", address);
        Console.WriteLine("Tel. {0}",number);
        if(fax == "")
        {
            Console.WriteLine("Fax: (no fax)");
        }
        else
        {
            Console.WriteLine("Fax: ",fax);
        }
        Console.WriteLine("Web site: {0}",site);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})",managerFirstName,managerLastName, managerAge, managerPhone);
    }
}

