namespace _02.EmployeeDAOClass
{
    using _01.SoftUniDatabase;

    public static class EmployeeDao
    {
        public static void Add(Employee employee)
        {
            var db = new SoftUniEntities();
            using (db)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public static Employee FindByKey(object key)
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var employee = db.Employees.Find(key);
                return employee;
            }
        }

        public static void Modify(Employee employee)
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var toModifyEmployee = db.Employees.Find(employee.EmployeeID);
                toModifyEmployee.FirstName = employee.FirstName;
                db.SaveChanges();
            }
        }

        public static void Delete(Employee employee)
        {
            var db = new SoftUniEntities();
            using (db)
            {
                var toDeleteEmployee = db.Employees.Find(employee.EmployeeID);
                db.Employees.Remove(toDeleteEmployee);
                db.SaveChanges();
            }
        }
    }
}
