namespace _06.StoredProcedure
{
    using System;
    using System.Globalization;
    using _01.SoftUniDatabase;

    class StoredProcedureMain
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var context = new SoftUniEntities();
            var projects = context.GetProjectsByemployee("Ruth", "Ellerbrock");
            foreach (var project in projects)
            {
                Console.WriteLine("{0} - {1}, {2:dd/MM/yyyy hh:mm:ss}", 
                    project.Name,
                    project.Description,
                    project.StartDate);
            }
        }
    }
}
