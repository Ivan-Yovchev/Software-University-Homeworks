using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using _01.ShowDataFromRelatedTables;

namespace _03._02.SelectOneColumnFromAds
{
    class SelectOneColumnMain
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
                var ads = db.Ads.Select(a => a.Title);
                foreach (var adTitle in ads)
                {
                    Console.WriteLine(adTitle);
                }

                stopwatch.Stop();
                average += stopwatch.Elapsed;
                file.WriteLine(stopwatch.Elapsed);
                stopwatch.Reset();
            }
            file.WriteLine(average.TotalSeconds / 10);
            file.Close();
        }
    }
}
