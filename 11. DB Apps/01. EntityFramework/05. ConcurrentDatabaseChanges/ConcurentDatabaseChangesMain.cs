using _01.SoftUniDatabase;

namespace _05.ConcurrentDatabaseChanges
{
    class ConcurentDatabaseChangesMain
    {
        static void Main()
        {
            var context1 = new SoftUniEntities();
            var context2 = new SoftUniEntities();

            var employee1 = context1.Employees.Find(1);
            var employee2 = context2.Employees.Find(1);

            //make changes
            employee1.FirstName = "Test1";
            employee2.FirstName = "Test2";

            context1.SaveChanges();
            context2.SaveChanges();

            // When Concurency Mode is NOT set to fixed
            // The last made change is the one that is saved
            // When Concurency Mode is set to fixed 
            // an exception is thrown
        }
    }
}
