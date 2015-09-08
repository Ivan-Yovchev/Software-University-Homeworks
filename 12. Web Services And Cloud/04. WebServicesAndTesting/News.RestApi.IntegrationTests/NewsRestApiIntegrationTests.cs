namespace News.RestApi.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using News.Models;
    using Owin;
    using Repositories;

    [TestClass]
    public class NewsRestApiIntegrationTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            // Start OWIN testing HTTP server with Web API support
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });
            this.httpClient = httpTestServer.HttpClient;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void ListAllNewsItems_ShouldReturn200Ok_AllNewsItemsList()
        {
            CleanDatabase();
            var repo = new NewsRepository(new NewsContext());
            repo.Add(
                new NewsItem
                {
                    Title = "Test Title #1",
                    Content = "Test Content #1",
                    PublishDate = DateTime.Now.AddDays(-2)
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Test Title #2",
                    Content = "Test Content #2",
                    PublishDate = DateTime.Now.AddDays(-1)
                });
            repo.SaveChanges();

            var httpResponse = httpClient.GetAsync("/api/news").Result;
            var newsItemsFromService = httpResponse.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");

            var newsFromDb = repo.All().ToList();
            Assert.AreEqual(newsFromDb.Count(), newsItemsFromService.Count());

            for (int i = 0; i < newsItemsFromService.Count; i++)
            {
                Assert.AreEqual(newsItemsFromService[i].Id, newsFromDb[i].Id);
                Assert.AreEqual(newsItemsFromService[i].Title, newsFromDb[i].Title);
                Assert.AreEqual(newsItemsFromService[i].Content, newsFromDb[i].Content);
                Assert.AreEqual(newsItemsFromService[i].PublishDate.ToString(), newsFromDb[i].PublishDate.ToString());
            }
        }

        [TestMethod]
        public void PostNewNewsItem_WhenValid_ShouldReturn201AndNewsIteCreated()
        {
            CleanDatabase();
            const string newsItemTitle = "Title #1";
            const string newsItemContent = "Content #1";
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", newsItemTitle),
                new KeyValuePair<string, string>("Content", newsItemContent),
                new KeyValuePair<string, string>("PublishDate", DateTime.Now.ToString()), 
            });
            var httpResponse = httpClient.PostAsync("/api/news", postContent).Result;
            var newsItemFromService = httpResponse.Content.ReadAsAsync<NewsItem>().Result;

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(httpResponse.Headers.Location);
            Assert.IsTrue(newsItemFromService.Id != 0);
            Assert.AreEqual(newsItemFromService.Title, newsItemTitle);
            Assert.AreEqual(newsItemFromService.Content, newsItemContent);
            Assert.IsNotNull(newsItemFromService.PublishDate);

            var repo = new NewsRepository(new NewsContext());
            var newsItemFromDb = repo.All().FirstOrDefault();
            Assert.IsNotNull(newsItemFromDb);
            Assert.AreEqual(newsItemFromService.Id, newsItemFromDb.Id);
            Assert.AreEqual(newsItemFromService.Title, newsItemFromDb.Title);
            Assert.AreEqual(newsItemFromService.Content, newsItemFromDb.Content);
            Assert.AreEqual(newsItemFromService.PublishDate.ToString(), newsItemFromDb.PublishDate.ToString());
        }

        [TestMethod]
        public void PostNewNewsItem_WhenInvalid_ShouldReturn400BadRequest()
        {
            CleanDatabase();
            const string newsItemTitle = null;
            const string newsItemContent = "Content #1";
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", newsItemTitle),
                new KeyValuePair<string, string>("Content", newsItemContent),
                new KeyValuePair<string, string>("PublishDate", DateTime.Now.ToString()), 
            });
            var httpResponse = httpClient.PostAsync("/api/news", postContent).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);

            var repo = new NewsRepository(new NewsContext());
            Assert.AreEqual(repo.All().Count(), 0);
        }

        [TestMethod]
        public void ModifyNewsItem_WhenValid_ShouldReturn200Ok()
        {
            CleanDatabase();

            var repo = new NewsRepository(new NewsContext());
            repo.Add(
                new NewsItem
                {
                    Title = "Title #1",
                    Content = "Content #1",
                    PublishDate = DateTime.Now
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #2",
                    Content = "Content #2",
                    PublishDate = DateTime.Now.AddDays(-1)
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #3",
                    Content = "Content #3",
                    PublishDate = DateTime.Now.AddDays(-2)
                });
            repo.SaveChanges();

            const string newNewsTitle = "Modified Title #2";
            const string newNewsContent = "Modified Content #2";

            var putContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", newNewsTitle),
                new KeyValuePair<string, string>("Content", newNewsContent) 
            });
            var httpResponse = httpClient.PutAsync("api/news/" + (repo.All().FirstOrDefault().Id + 1), putContent).Result;
            var newsItemFromService = httpResponse.Content.ReadAsAsync<NewsItem>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(newsItemFromService.Title, newNewsTitle);
            Assert.AreEqual(newsItemFromService.Content, newNewsContent);
        }

        [TestMethod]
        public void ModifyNewsItem_WhenInvalid_ShouldReturn400BadRequest()
        {
            CleanDatabase();

            var repo = new NewsRepository(new NewsContext());
            repo.Add(
                new NewsItem
                {
                    Title = "Title #1",
                    Content = "Content #1",
                    PublishDate = DateTime.Now
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #2",
                    Content = "Content #2",
                    PublishDate = DateTime.Now.AddDays(-1)
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #3",
                    Content = "Content #3",
                    PublishDate = DateTime.Now.AddDays(-2)
                });
            repo.SaveChanges();

            const string newNewsTitle = null;
            const string newNewsContent = "Modified Content #2";

            var putContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", newNewsTitle),
                new KeyValuePair<string, string>("Content", newNewsContent) 
            });
            var httpResponse = httpClient.PutAsync("api/news/" + (repo.All().FirstOrDefault().Id + 1), putContent).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeleteNewsItem_WhenValid_ShouldReturn200Ok()
        {
            CleanDatabase();

            var repo = new NewsRepository(new NewsContext());
            repo.Add(
                new NewsItem
                {
                    Title = "Title #1",
                    Content = "Content #1",
                    PublishDate = DateTime.Now
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #2",
                    Content = "Content #2",
                    PublishDate = DateTime.Now.AddDays(-1)
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #3",
                    Content = "Content #3",
                    PublishDate = DateTime.Now.AddDays(-2)
                });
            repo.SaveChanges();
            var httpResponse = httpClient.DeleteAsync("api/news/" + (repo.All().FirstOrDefault().Id + 1)).Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(repo.All().Count(), 2);
        }

        [TestMethod]
        public void DeleteNewsItem_WhenInvalid_ShouldReturn400BadRequest()
        {
            CleanDatabase();

            var repo = new NewsRepository(new NewsContext());
            repo.Add(
                new NewsItem
                {
                    Title = "Title #1",
                    Content = "Content #1",
                    PublishDate = DateTime.Now
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #2",
                    Content = "Content #2",
                    PublishDate = DateTime.Now.AddDays(-1)
                });
            repo.Add(
                new NewsItem
                {
                    Title = "Title #3",
                    Content = "Content #3",
                    PublishDate = DateTime.Now.AddDays(-2)
                });
            repo.SaveChanges();

            var invalidId = (repo.All().FirstOrDefault().Id + 3);
            var httpResponse = httpClient.DeleteAsync("api/news/" + invalidId).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(repo.All().Count(), 3);
        }

        private void CleanDatabase()
        {
            // Clean all data in all database tables
            var dbContext = new NewsContext();
            dbContext.News.Delete();
            dbContext.SaveChanges();
        }
    }
}
