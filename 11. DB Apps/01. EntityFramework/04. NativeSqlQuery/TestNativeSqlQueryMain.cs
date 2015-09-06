

namespace _04.NativeSqlQuery
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using _01.SoftUniDatabase;

    class TestNativeSqlQueryMain
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var totalCount = context.Employees.Count();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            PrintNamesWithNativeQuery(context);
            Console.WriteLine("Native: {0}", stopWatch.Elapsed);

            stopWatch.Restart();

            PrintNamesWithLinqQuery(context);
            Console.WriteLine("Linq: {0}", stopWatch.Elapsed);
        }

        public static void PrintNamesWithNativeQuery(SoftUniEntities context)
        {
            var names = context.Database.SqlQuery<string>(
                "SELECT DISTINCT e.FirstName"
                + " FROM EmployeesProjects ep"
                + " JOIN Employees e"
                + " ON ep.EmployeeID = e.EmployeeID"
                + " JOIN Projects p"
                + " ON ep.ProjectID = p.ProjectID"
                + " WHERE YEAR(p.StartDate) = 2002").ToList();

            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}
        }

        public static void PrintNamesWithLinqQuery(SoftUniEntities context)
        {
            var names = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName)
                .Distinct();

            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}
        }
    }
}
