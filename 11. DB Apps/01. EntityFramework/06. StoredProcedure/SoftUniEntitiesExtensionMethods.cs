namespace _06.StoredProcedure
{
    using _01.SoftUniDatabase;
    using System.Collections.Generic;
    using System.Linq;

    public static class SoftUniEntitiesExtensionMethods
    {
        public static List<usp_GetProjectsByEmployee_Result> GetProjectsByemployee(this SoftUniEntities context, string firstName, string lastName)
        {
            var projects = context.usp_GetProjectsByEmployee(firstName, lastName).ToList();

            return projects;
        }
    }
}
