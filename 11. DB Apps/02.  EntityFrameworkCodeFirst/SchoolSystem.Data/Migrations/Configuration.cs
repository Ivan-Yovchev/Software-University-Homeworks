namespace SchoolSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SchoolSystem.Data.SchoolSystemContext";
        }

        protected override void Seed(SchoolSystemContext context)
        {
            if (!context.Homeworks.Any() && !context.Resources.Any() && !context.Students.Any() && !context.Courses.Any())
            {
                var studentNames = new string[]
                {
                   "Alesia Koval",
                   "Henriette Caffey",
                   "Camie Fenley",
                   "Danae Harbert",
                   "Shelia Kagawa",
                   "Sanjuanita Music",
                   "Ayana Gervasi",
                   "Vonda Gardener",
                   "Micah Lueders",
                   "Jospeh Aldinger",
                   "Rolf Ryals",
                   "Vena Testerman",
                   "Tama Halvorson",
                   "Beula Branco",
                   "Lecia Leija",
                   "Bessie Wellington",
                   "Fidel Getty",
                   "Latasha Bear",
                   "Cathleen Cuthbertson",
                   "Wenona Krupp",
                   "Laraine Kirksey",
                   "Lizzette Mcclaine",
                   "Kalyn Rosebrock",
                   "Johnna Brouwer",
                   "Hien Real",
                   "Juan Zinke",
                   "Merna Towe",
                   "Reynaldo Mcelveen",
                   "Susanna Talmadge",
                   "Kirby Wasson",
                   "Ola Benigno",
                   "Terri Kaczor",
                   "Tonya Barron",
                   "Chad Crader",
                   "Enoch Junk",
                   "Lucius Thorn",
                   "Vernon Stouffer",
                   "Dovie Goldblatt",
                   "Lorrie Burkhart",
                   "Nicola Launer",
                   "Ardelle Gallagher",
                   "Sherrill Bigler",
                   "Bennett Munford",
                   "Maurita Eggleston",
                   "Maragaret Guillotte",
                   "Pilar Hammer",
                   "Cindy Comes",
                   "Brenda Hilden",
                   "Hanh Anders",
                   "Benedict Well",
                };

                var phones = new string[]
                {
                    "0893838318",
                    "0891902389",
                    "0891782920",
                    "0899237834",
                    "0896898976",
                    "0890987901",
                    "0891902120",
                    "0892345678",
                    "0891010710",
                    "0893456789"
                };

                var courseTitles = new string[]
                {
                    "Programing Basics",
                    "New Product Development",
                    "QA Fundamentals",
                    "Advanced C#",
                    "Object-Oriented Programing",
                    "High-Quality Code",
                    "Java Basics",
                    "Teamwork And Personal Skills",
                    "Web Fundamentals",
                    "JavaScript Basics",
                    "Advanced JavaScript",
                    "JavaScript Frameworks",
                    "Databases",
                    "Database Apps",
                    "Web Service And Cloud",
                    "PHP Basics",
                    "Web Development Basics",
                    "ASP.NET MVC",
                    "Data Structures",
                    "Digital Marketing and SEO",
                    "Unity 3D",
                    "Linux System Administration"
                };

                var loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
                var url = "http://someurl.com";
                var name = "Some Name";

                var random = new Random();

                // Courses
                for (int i = 0; i < 10; i++)
                {
                    var course = new Course()
                    {
                        Name = courseTitles[random.Next(0,courseTitles.Length)],
                        Description = loremIpsum,
                        StartDate = DateTime.Now.AddDays(random.Next(-1000, 1000)),
                        EndDate = DateTime.Now.AddDays(random.Next(1000, 2000)),
                        Price = random.Next(0, 1501)
                    };

                    context.Courses.Add(course);
                }
                context.SaveChanges();

                // Students
                for (int i = 0; i < 25; i++)
                {
                    var student = new Student()
                    {
                        Name = studentNames[random.Next(0, studentNames.Length)],
                        PhoneNumber = phones[random.Next(0, phones.Length)],
                        RegistrationDate = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        Birthday = DateTime.Now.AddYears(random.Next(-20, 0))
                    };

                    for (int j = 0; j < random.Next(1, 6); j++)
                    {
                        var course = context.Courses.Find(random.Next(1, context.Courses.Count()) + 1);
                        if (!student.Courses.Contains(course))
                        {
                            student.Courses.Add(course);
                        }
                    }

                    context.Students.Add(student);
                }
                context.SaveChanges();

                // Homework
                for (int i = 0; i < 50; i++)
                {
                    var course = context.Courses.Find(random.Next(1, context.Courses.Count()));

                    var student = context.Students.Find(random.Next(1, context.Students.Count()));

                    var contentId = random.Next(0, 3);
                    ContentType content = ContentType.Application;
                    switch (contentId)
                    {
                        case 0: content = ContentType.Application;
                            break;
                        case 1: content = ContentType.Pdf;
                            break;
                        case 2: content = ContentType.Zip;
                            break;
                    }

                    var homework = new Homework()
                    {
                        Content = loremIpsum,
                        SubmissionDate = DateTime.Now.AddDays(random.Next(-20, 0)),
                        CourseId = course.Id,
                        ContentType = content,
                        StudentId = student.Id
                    };

                    context.Homeworks.Add(homework);
                }
                context.SaveChanges();

                // Resources
                for (int i = 0; i < 50; i++)
                {
                    var course = context.Courses.Find(random.Next(1, context.Courses.Count()));

                    var resourceId = random.Next(0, 4);
                    ResourceType resourceType = ResourceType.Document;
                    switch (resourceId)
                    {
                        case 0:
                            resourceType = ResourceType.Document;
                            break;
                        case 1:
                            resourceType = ResourceType.Presentation;
                            break;
                        case 2:
                            resourceType = ResourceType.Video;
                            break;
                        case 3:
                            resourceType = ResourceType.Other;
                            break;
                    }

                    var resource = new Resource()
                    {
                        Name = name,
                        ResourceType = resourceType,
                        Url = url,
                        CourseId = course.Id
                    };

                    context.Resources.Add(resource);
                }
                context.SaveChanges();
            }
        }
    }
}
