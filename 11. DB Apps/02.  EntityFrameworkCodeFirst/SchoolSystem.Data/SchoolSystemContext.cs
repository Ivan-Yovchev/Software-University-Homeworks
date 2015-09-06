namespace SchoolSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;
    using Migrations;

    public class SchoolSystemContext : DbContext
    {
        public SchoolSystemContext()
            : base("SchoolSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemContext, Configuration>());
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Resource> Resources { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}