namespace _01.SoftUniDatabase
{
    using System;
    using System.Linq;

    class SoftUniDatabaseMain
    {
        static void Main()
        {
            var db = new SoftUniEntities();

            var id = db.Employees
                .Where(x => x.EmployeeID == 1)
                .Select(x => x.EmployeeID)
                .FirstOrDefault();

            Console.WriteLine(id);
        }
    }
}
