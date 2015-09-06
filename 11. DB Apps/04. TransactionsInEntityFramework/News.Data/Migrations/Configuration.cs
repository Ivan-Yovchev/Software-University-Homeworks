using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace News.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "News.Data.NewsEntities";
        }

        protected override void Seed(NewsEntities context)
        {
            if (!context.News.Any())
            {
                var headlines = new string[]
                {
                    "Traders Profit As nytimes: Traders Profit as Power Grid Is Overworked Legal Costs Eased, Site Says",
                    "We Found Out How Much Would It Be Evil to Build A Supersonic Business Jet to Fly On Alien Worlds?",
                    "Captain Marvel Thinks",
                    "Sanjay Gupta Uses Chocolate Sauce to Show Off 'Fallout 4' Is Probably Too Awkward to Hear In Real Life Imitates",
                    "Why It Was A Total Disaster",
                    "Bob Dylan Giving New Album Songs of All Time For The First Town Into Hell On The Rocks?",
                    "Should Superhero Movies Have You Played Start-To-Finish More Than You Think 'Coming",
                    "The Makings of An Active Lava Flow, Is An Acceptable Idea",
                    "3 Ways Italy Is Trying To Live in One.",
                    "World Briefing: Syria: Bomb Kills More Than One Way To Read People's Body Language Tips To Avoid People Who Live in L.A."
                };

                for (int i = 0; i < headlines.Length; i++)
                {
                    var news = new News()
                    {
                        NewsContent = headlines[i]
                    };
                    context.News.Add(news);
                }
            }
        }
    }
}
