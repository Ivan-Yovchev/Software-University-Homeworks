using _01.ShowDataFromRelatedTables;

namespace _03._01.SelectingEveryColumnFromAds
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    class SelectingEverythingMain
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
                foreach (var ad in db.Ads)
                {
                    Console.WriteLine(ad.Title);
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
