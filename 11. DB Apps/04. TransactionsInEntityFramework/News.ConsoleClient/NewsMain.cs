using System;
using System.Linq;
using News.Data;

namespace News.ConsoleClient
{
    class NewsMain
    {
        static void Main()
        {
            var db = new NewsEntities();
            var contextFirst = new NewsEntities();
            var contextSecond = new NewsEntities();

            var newsFirst = contextFirst.News.Find(1);
            Console.WriteLine("Text From DB: " + newsFirst.NewsContent);
            Console.Write("Enter the corrected text: ");
            newsFirst.NewsContent = Console.ReadLine();

            var newsSecond = contextSecond.News.Find(1);
            Console.WriteLine("Text From DB: " + newsSecond.NewsContent);
            Console.Write("Enter the corrected text: ");
            newsSecond.NewsContent = Console.ReadLine();

            contextFirst.SaveChanges();
            try
            {
                contextSecond.SaveChanges();
            }
            catch (Exception c)
            {
                Console.WriteLine("Conflict!!!");
                var thirdNewsContext = new NewsEntities();

                var newsWithNewValue = thirdNewsContext.News.Find(1);

                Console.WriteLine("Text from DB: " + newsWithNewValue.NewsContent);
                Console.Write("Enter the correct text: ");

                newsWithNewValue.NewsContent = Console.ReadLine();

                thirdNewsContext.SaveChanges();
            }
        }
    }
}
