namespace MusicShopManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MusicShopManager.Interfaces;

    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of a music shop is required.");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get
            {
                return this.articles;
            }

            private set
            {
                this.articles = value;
            }
        }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder musicShop = new StringBuilder();
            musicShop.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name).AppendLine();
            if (this.articles.Count == 0)
            {
                musicShop.Append("The shop is empty. Come back soon.").AppendLine();
            }
            else
            {
                var microphones = this.articles.Where(item => item is Microphone);
                musicShop.Append(SortCategories(microphones, "Microphones"));

                var drums = this.articles.Where(item => item is Drums);
                musicShop.Append(SortCategories(drums, "Drums"));

                var electricGuitars = this.articles.Where(item => item is ElectricGuitar);
                musicShop.Append(SortCategories(electricGuitars, "Electric guitars"));

                var acousticGuitars = this.articles.Where(item => item is AcousticGuitar);
                musicShop.Append(SortCategories(acousticGuitars, "Acoustic guitars"));

                var bassGiutars = this.articles.Where(item => item is BassGuitar);
                musicShop.Append(SortCategories(bassGiutars, "Bass guitars"));
            }

            return musicShop.ToString();
        }

        private string SortCategories(IEnumerable<IArticle> items, string category)
        {
            if (items.Count() == 0)
            {
                return string.Empty;
            }

            StringBuilder joinedItems = new StringBuilder();
            joinedItems.AppendFormat("{0} {1} {0}", new string('-', 5), category).AppendLine();
            items = items.OrderBy(a => a.Make + " " + a.Model);
            foreach (var item in items)
            {
                joinedItems.Append(item.ToString());
            }

            return joinedItems.ToString();
        }
    }
}
