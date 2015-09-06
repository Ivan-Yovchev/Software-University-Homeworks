namespace SchoolSystem.ConsoleClient
{
    using Data;
    using System;
    using System.Linq;
    using System.Data.Entity.Core.Objects;

    internal class SchoolSystemMain
    {
        private static void Main()
        {
            //AllStudents();
            //AllCourses();
            //AllCoursesByResourceCount();
            //CoursesActiveOnAGivenDate();
            StudentCourseFees();
        }

        public static void AllStudents()
        {
            Console.WriteLine("All students with their homeworks: ");
            var db = new SchoolSystemContext();
            using (db)
            {
                var students = db.Students.Select(s => new
                {
                    Name = s.Name,
                    Homeworks = s.Homeworks
                });

                foreach (var student in students)
                {
                    foreach (var homework in student.Homeworks)
                    {
                        Console.WriteLine("Name: {0}, Content: {1}, Content-Type: {2}{3}",
                            student.Name,
                            homework.Content,
                            homework.ContentType,
                            Environment.NewLine);
                    }
                }
            }
        }

        public static void AllCourses()
        {
            Console.WriteLine("All courses with their resources: ");
            var db = new SchoolSystemContext();
            using (db)
            {
                var courses = db.Courses
                    .OrderBy(c => c.StartDate)
                    .ThenByDescending(c => c.EndDate)
                    .Select(c => new
                    {
                        c.Name,
                        c.Description,
                        c.Resources
                    });

                foreach (var course in courses)
                {
                    foreach (var resource in course.Resources)
                    {
                        Console.WriteLine(
                            "Course name: {0}, Description: {1}, Resource Name: {2}, Url: {3}, Resource-Type: {4}{5}",
                            course.Name,
                            course.Description,
                            resource.Name,
                            resource.Url,
                            resource.ResourceType,
                            Environment.NewLine);
                    }
                }
            }
        }

        public static void AllCoursesByResourceCount()

        {
            Console.WriteLine("All courses with more than 5 resources: ");
            var db = new SchoolSystemContext();
            using (db)
            {
                var courses = db.Courses
                    .Where(c => c.Resources.Count() > 5)
                    .OrderByDescending(c => c.Resources.Count())
                    .ThenByDescending(c => c.StartDate)
                    .Select(s => new
                    {
                        s.Name,
                        ResourceCount = s.Resources.Count()
                    });

                foreach (var course in courses)
                {
                    Console.WriteLine("Course Name: {0}, Resources Count: {1}{2}",
                        course.Name,
                        course.ResourceCount,
                        Environment.NewLine);
                }
            }
        }

        public static void CoursesActiveOnAGivenDate()
        {
            Console.WriteLine("All courses active on the current date: ");
            var db = new SchoolSystemContext();
            using (db)
            {
                var courses = db.Courses
                    .OrderByDescending(c => EntityFunctions.DiffDays(c.StartDate, c.EndDate))
                    .ThenByDescending(c => c.Students.Count())
                    .Select(c => new
                    {
                        c.Name,
                        c.StartDate,
                        c.EndDate,
                        Duration = EntityFunctions.DiffDays(c.StartDate, c.EndDate),
                        StudentsCount = c.Students.Count()
                    });

                foreach (var course in courses)
                {
                    Console.WriteLine("Course Name: {0}, Start Date: {1:dd.MM.yyyy}, End Date: {2:dd.MM.yyyy}, Duration: {3} days, Students Count: {4}",
                        course.Name,
                        course.StartDate,
                        course.EndDate,
                        course.Duration,
                        course.StudentsCount);
                }
            }
        }

        public static void StudentCourseFees()
        {
            Console.WriteLine("Number of courses a students has enrolled in with total and average price: ");
            var db = new SchoolSystemContext();
            using (db)
            {
                var students = db.Students.Select(s => new
                {
                    Count = s.Courses.Count(),
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AveragePrice = s.Courses.Average(c => c.Price),
                    s.Name
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.Count)
                .ThenBy(s => s.Name);

                foreach (var student in students)
                {
                    Console.WriteLine("Student: {0}, Total Courses: {1}, Total Price: {2:F2}, Average Price: {3:F2}",
                        student.Name,
                        student.Count,
                        student.TotalPrice,
                        student.AveragePrice);
                }
            }
        }
    }
}
