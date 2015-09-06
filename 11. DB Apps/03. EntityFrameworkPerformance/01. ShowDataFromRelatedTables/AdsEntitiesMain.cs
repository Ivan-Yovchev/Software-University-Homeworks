namespace _01.ShowDataFromRelatedTables
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class AdsEntitiesMain
    {
        static void Main()
        {
            var db = new AdsEntities();
            var start = db.Ads.Count();
            var ads = db.Ads
                .Include(a => a.Category)
                .Include(a => a.AdStatus)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            foreach (var ad in ads)
            {
                if (ad.Category == null)
                {
                    ad.Category = new Category()
                    {
                        Name = "Null"
                    };
                }

                if (ad.Town == null)
                {
                    ad.Town = new Town()
                    {
                        Name = "Null"
                    };
                }

                Console.WriteLine("Title: {0}, Status: {1}, Category: {2}, Town: {3}, User: {4}",
                    ad.Title,
                    ad.AdStatus.Status,
                    ad.Category.Name,
                    ad.Town.Name,
                    ad.AspNetUser.UserName);
            }
        }
    }
}
