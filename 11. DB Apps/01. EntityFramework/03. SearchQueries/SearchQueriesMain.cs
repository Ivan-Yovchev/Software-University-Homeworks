using System;

namespace _03.SearchQueries
{
    using System.Threading;

    class SearchQueriesMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            //Console.WriteLine("Employees Who Have Project With Start Date Year Between 2001 And 2003");
            //Queries.EmployeesProjects();

            //Console.WriteLine();
            //Console.WriteLine("Top 10 Addresses by employee count");
            //Queries.AddressesAndEmployeesCount();

            //Console.WriteLine();
            //Console.WriteLine("All employee data and their projects");
            //Queries.EmployeeData();

            Console.WriteLine();
            Console.WriteLine("All department with more than 5 employees and their managers");
            Queries.DepartmentsAndEmployees();
        }
    }
}
