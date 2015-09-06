namespace _02._02.PlayingWithToListOptimized
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using _01.ShowDataFromRelatedTables;
    using System.Data.Entity;

    class OptimizedToListMain
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
                    .Include(a => a.Category)
                    .Include(a => a.Town)
                    .Include(a => a.AdStatus)
                    .Where(a => a.AdStatus.Status == "Published")
                    .OrderBy(a => a.Date)
                    .Select(a => new
                    {
                        a.Title,
                        Category = a.Category,
                        Town = a.Town
                    });

                stopwatch.Stop();
                average += stopwatch.Elapsed;
                Console.WriteLine(stopwatch.Elapsed);
                file.WriteLine(stopwatch.Elapsed);
            }
            Console.WriteLine("Average: " + average.TotalSeconds / 10);
            file.WriteLine(average.TotalSeconds / 10);
            file.Close();
        }
    }
}
