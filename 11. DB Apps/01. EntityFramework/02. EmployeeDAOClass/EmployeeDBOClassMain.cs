namespace _02.EmployeeDAOClass
{
    using _01.SoftUniDatabase;

    class EmployeeDboClassMain
    {
        private const int EmployeeId = 294;
        static void Main()
        {
            var db = new SoftUniEntities();
            using (db)
            {
                //var employee = new Employee()
                //{
                //    FirstName = "Ivan",
                //    LastName = "Ivanov",
                //    JobTitle = "Marketing Assistant",
                //    DepartmentID = db.Departments
                //        .Where(x => x.Name == "Marketing")
                //        .Select(x => x.DepartmentID)
                //        .FirstOrDefault(),
                //    HireDate = DateTime.Now.AddDays(23),
                //    Salary = 9500
                //};
                //EmployeeDao.Add(employee);

                //var foundEmployee = EmployeeDao.FindByKey(EmployeeId);
                //Console.WriteLine(foundEmployee.EmployeeID);

                var employee2 = db.Employees.Find(EmployeeId);
                employee2.FirstName = "Misho";
                EmployeeDao.Modify(employee2);

                EmployeeDao.Delete(employee2);
            }
        }
    }
}
