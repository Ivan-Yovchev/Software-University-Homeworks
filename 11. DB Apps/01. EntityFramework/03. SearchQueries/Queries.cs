namespace _03.SearchQueries
{
    using System;
    using System.Linq;
    using _01.SoftUniDatabase;

    public static class Queries
    {
        public static void EmployeesProjects()
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var employees = db.Employees
                    .Where(e => e.Projects
                        .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                    .Join(db.Employees, (e => e.ManagerID), (m => m.EmployeeID), (e, m) => new
                    {
                        ManagerName = m.FirstName + " " + m.LastName,
                        Projects = e.Projects
                    })
                    .ToList();

                foreach (var employee in employees)
                {
                    foreach (var project in employee.Projects)
                    {
                        Console.WriteLine("Project Name: {0}", project.Name);
                        Console.WriteLine("Start Date: {0:dd-MM-yyyy}", project.StartDate);
                        Console.WriteLine("End Date: {0:dd-MM-yyyy}", project.EndDate);
                        Console.WriteLine("Project Manager: {0}", employee.ManagerName);
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void AddressesAndEmployeesCount()
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var addresses = db.Addresses
                    .Select(a => new
                    {
                        Address = a.AddressText,
                        Town = a.Town.Name,
                        EmployeesCount = a.Employees.Count
                    })
                    .OrderByDescending(x => x.EmployeesCount)
                    .ThenBy(x => x.Town)
                    .Take(10);

                foreach (var address in addresses)
                {
                    Console.WriteLine("{0}, {1} - {2} employees", address.Address, address.Town, address.EmployeesCount);
                }
            }
        }

        public static void EmployeeData()
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var employee = db.Employees
                    .Where(e => e.EmployeeID == 147)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        Projects = e.Projects.OrderBy(p => p.Name)
                    })
                    .FirstOrDefault();

                Console.WriteLine("Name: {0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("Job Title: {0}", employee.JobTitle);
                Console.WriteLine("Projects:");
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("-- " + project.Name);
                }
            }
        }

        public static void DepartmentsAndEmployees()
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var departments = db.Departments
                    .Where(d => d.Employees.Count > 5)
                    .Join(db.Employees, (d => d.ManagerID), (m => m.EmployeeID), (d, m) => new
                    {
                        DepartmentName = d.Name,
                        ManagerName = m.LastName,
                        Employees = d.Employees.Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.HireDate,
                            e.JobTitle
                        })
                    })
                    .OrderBy(d => d.Employees.Count());

                Console.WriteLine(departments.Count());

                foreach (var department in departments)
                {
                    Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                        department.DepartmentName,
                        department.ManagerName,
                        department.Employees.Count());
                }
            }
        }
    }
}
