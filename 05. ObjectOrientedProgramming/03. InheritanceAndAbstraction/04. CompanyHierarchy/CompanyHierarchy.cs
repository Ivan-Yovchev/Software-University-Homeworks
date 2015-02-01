using System;
using System.Collections.Generic;

class CompanyHierarchy
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Project operaSpy = new Project("Opera Spy", new DateTime(2014, 2, 23), "Script", State.Closed);
        Project hospitalTokuda = new Project("Tokuda Care", new DateTime(2014, 5, 15), "Patient management system for Tokuda Hospital", State.Opened);
        Project eShopWebSite = new Project("EShop ASP.Net", new DateTime(2014, 7, 30), "A website with ASP.Net for an australian trading company", State.Opened);

        Sale operaSpySale = new Sale("Opera Spy", new DateTime(2014, 08, 15), 2340m);
        Sale wordpressPortfolioTemplate = new Sale("Wordpress portfolio", new DateTime(2014, 03, 10), 220m);
        Sale firealarm = new Sale("Firealarm game", new DateTime(2013, 07, 25), 2000m);
        Sale memoryMatrix = new Sale("Memory Matrix", new DateTime(2014, 09, 5), 1800m);
        Sale bankERP = new Sale("UCB ERP", new DateTime(2014, 02, 02), 20340m);

        Employee pesho = new SalesEmployee("pp", "Petar", "Petrov", 20000m, Department.Sales, new List<ISale>() { operaSpySale, firealarm });
        Employee gosho = new SalesEmployee("gb", "Georgi", "Balabanov", 24000m, Department.Sales, new List<ISale>() { wordpressPortfolioTemplate, memoryMatrix });
        Employee marinka = new SalesEmployee("md", "Marinka", "Dicheva", 30000m, Department.Marketing, new List<ISale>() { bankERP });

        Employee gergana = new Developer("gm", "Gergana", "Mihailova", 25000, Department.Production, new List<IProject>() { operaSpy, eShopWebSite, hospitalTokuda });
        Employee dimana = new Developer("dm", "Dimana", "Mihailova", 28000, Department.Production, new List<IProject>() { operaSpy, hospitalTokuda });
        Employee donka = new Developer("dk", "Donka", "Karamanova", 15000, Department.Production, new List<IProject>() { hospitalTokuda });

        Manager petranka = new Manager("pk", "Petranka", "Karadocheva", 38000m, Department.Production, new List<Employee>() { dimana, donka, });
        Manager krastanka = new Manager("kk", "Krastanka", "Kurteva", 30000m, Department.Production, new List<Employee>() { gergana });
        Manager tsvetana = new Manager("tm", "Tsvetana", "Marinova", 35000m, Department.Marketing, new List<Employee>() { pesho, gosho, marinka });

        List<Employee> employees = new List<Employee>() { 
            pesho, gosho, marinka, gergana, tsvetana, krastanka, petranka, donka, dimana, };

        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }

    }
}
