namespace News.RestApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models.BindingModels;
    using News.Models;
    using Repositories;

    public class NewsController : ApiController
    {
        private readonly IRepository<NewsItem> repo;

        public NewsController()
            : this(new NewsRepository(new NewsContext()))
        {
        }

        public NewsController(IRepository<NewsItem> repository)
        {
            this.repo = repository;
        }

        [HttpGet]
        [Route("api/news")]
        public IQueryable<NewsItem> GetAllNews()
        {
            return this.repo.All();
        }

        [HttpPost]
        [Route("api/news")]
        public IHttpActionResult PostNewsItem(NewsItemBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newsItem = new NewsItem
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = DateTime.Now
            };

            this.repo.Add(newsItem);
            this.repo.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { controller = "NewsController", id = newsItem.Id }, newsItem);
        }

        [HttpPut]
        [Route("api/news/{id}")]
        public IHttpActionResult ModifyNewsItem(int id, NewsItemBindingModel model)
        {
            try
            {
                var newsItem = this.repo.Find(id);
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                newsItem.Title = model.Title;
                newsItem.Content = model.Content;
                this.repo.SaveChanges();

                return this.Ok(newsItem);
            }
            catch (Exception)
            {
                return this.BadRequest("No news item with id " + id);
            }
        }

        [HttpDelete]
        [Route("api/news/{id}")]
        public IHttpActionResult DeleteNewsItem(int id)
        {
            try
            {
                var newsItem = this.repo.Find(id);
                this.repo.Delete(newsItem);
                this.repo.SaveChanges();

                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest("No news item with id " + id);
            }
        }
    }
}