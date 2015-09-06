using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using _01.ShowDataFromRelatedTables;

namespace _02._01.PlayingWithToListNotOptimized
{
    class NotOptimizedToListMain
    {
        static void Main()
        {
            var db = new AdsEntities();
            var start = db.Ads.Count();

            var stopwatch = new Stopwatch();
            TimeSpan average = new TimeSpan(0);
            StreamWriter file = new StreamWriter("result.txt");
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                var ads = db.Ads
                    .ToList()
                    .Where(a => a.AdStatus.Status == "Published")
                    .Select(a => new
                    {
                        a.Title,
                        Category = a.Category,
                        Town = a.Town,
                        a.Date
                    })
                    .ToList()
                    .OrderBy(a => a.Date);
                stopwatch.Stop();
                average += stopwatch.Elapsed;
                Console.WriteLine(stopwatch.Elapsed);
                file.WriteLine(stopwatch.Elapsed);
            }
            Console.WriteLine("Average: " + average.TotalSeconds/10);
            file.WriteLine(average.TotalSeconds/10);
            file.Close();
        }
    }
}
