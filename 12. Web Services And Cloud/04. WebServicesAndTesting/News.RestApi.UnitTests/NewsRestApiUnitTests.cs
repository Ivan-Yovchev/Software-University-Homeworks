namespace News.RestApi.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.BindingModels;
    using Moq;
    using News.Models;
    using Repositories;

    [TestClass]
    public class NewsRestApiUnitTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnNewsItemsCollection_WithMoq()
        {
            var repoMock = new Mock<IRepository<NewsItem>>();

            NewsItem[] news =
            {
                new NewsItem()
                {
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now
                },
                new NewsItem()
                {
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                },
                new NewsItem()
                {
                    Title = "Title #3", 
                    Content = "Content #3", 
                    PublishDate = DateTime.Now.AddDays(-2)
                }
            };

            repoMock
                .Setup(repo => repo.All())
                .Returns(news.AsQueryable());

            var controller = new NewsController(repoMock.Object);
            var result = controller.GetAllNews();

            CollectionAssert.AreEquivalent(news, result.ToArray());
        }

        [TestMethod]
        public void PostNewsItem_WhenValid_ShouldAddNewsItemToDb_WithMoq()
        {
            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                }
            };

            repoMock
                .Setup(repo => repo.Add(It.IsAny<NewsItem>()))
                .Callback((NewsItem n) => news.Add(n));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");
            var bindingModel = new NewsItemBindingModel
            {
                Title = "Title #3",
                Content = "Content #3"
            };
            controller.Validate(bindingModel);
            var result = controller.PostNewsItem(bindingModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Assert.AreEqual(bindingModel.Title, news.Last().Title);
            Assert.AreEqual(bindingModel.Content, news.Last().Content);
            Assert.IsNotNull(news.Last().PublishDate);
        }

        [TestMethod]
        public void PostNewsItem_WhenInvalid_ShouldReturnBadRequest_WithMoq()
        {
            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                }
            };

            repoMock
                .Setup(repo => repo.Add(It.IsAny<NewsItem>()))
                .Callback((NewsItem n) => news.Add(n));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");

            var bindingModel = new NewsItemBindingModel
            {
                Title = null,
                Content = "Content #3"
            };
            controller.Validate(bindingModel);
            var result = controller.PostNewsItem(bindingModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void ModifyNewsItem_WhenValid_ShouldModifyNewsItem_WithMoq()
        {
            const int newsItemIdToModify = 2;

            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Id = 1,
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Id = 2,
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                }
            };

            repoMock
                .Setup(repo => repo.Find(It.IsAny<int>()))
                .Returns((int id) => news.FirstOrDefault(n => n.Id == id));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");

            var bindingModel = new NewsItemBindingModel
            {
                Title = "Modified Title #2",
                Content = "Modified Content #2"
            };
            controller.Validate(bindingModel);
            var result = controller.ModifyNewsItem(newsItemIdToModify, bindingModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(bindingModel.Title, news.Last().Title);
            Assert.AreEqual(bindingModel.Content, news.Last().Content);
        }

        [TestMethod]
        public void ModifyNewsItem_WhenInvalid_ShouldReturnBadRequest_WithMoq()
        {
            const int newsItemIdToModify = 2;

            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Id = 1,
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Id = 2,
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                }
            };

            repoMock
                .Setup(repo => repo.Find(It.IsAny<int>()))
                .Returns((int id) => news.FirstOrDefault(n => n.Id == id));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");

            var bindingModel = new NewsItemBindingModel
            {
                Title = "Modified Title #2",
                Content = null
            };
            controller.Validate(bindingModel);
            var result = controller.ModifyNewsItem(newsItemIdToModify, bindingModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void ModifyNewsItem_WhenNonExistent_ShouldReturnBadRequest_WithMoq()
        {
            const int newsItemIdToModify = 12;

            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Id = 1,
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Id = 2,
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                }
            };

            repoMock
                .Setup(repo => repo.Find(It.IsAny<int>()))
                .Returns((int id) => news.FirstOrDefault(n => n.Id == id));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");

            var bindingModel = new NewsItemBindingModel
            {
                Title = "Modified Title #2",
                Content = "Modified Content #2"
            };
            controller.Validate(bindingModel);
            var result = controller.ModifyNewsItem(newsItemIdToModify, bindingModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void DeleteNewsItem_WhenValid_ShouldDeleteItemFromDb_WithMoq()
        {
            const int newsItemIdToDelete = 2;

            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Id = 1,
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Id = 2,
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                },
                new NewsItem()
                {
                    Id = 3,
                    Title = "Title #3", 
                    Content = "Content #3", 
                    PublishDate = DateTime.Now.AddDays(-2)
                }
            };

            repoMock
                .Setup(repo => repo.Find(It.IsAny<int>()))
                .Returns((int id) => news.FirstOrDefault(n => n.Id == id));
            repoMock
                .Setup(repo => repo.Delete(It.IsAny<NewsItem>()))
                .Callback((NewsItem item) => news.RemoveAt(item.Id - 1));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");

            var result = controller.DeleteNewsItem(newsItemIdToDelete).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(news.Count(), 2);
        }

        [TestMethod]
        public void DeleteNewsItem_WhenNonExistent_ShouldReturnBadrequest_WithMoq()
        {
            const int newsItemIdToDelete = 12;

            var repoMock = new Mock<IRepository<NewsItem>>();

            List<NewsItem> news = new List<NewsItem>()
            {
                new NewsItem()
                {
                    Id = 1,
                    Title = "Title #1", 
                    Content = "Content #1", 
                    PublishDate = DateTime.Now.AddDays(-2)
                },
                new NewsItem()
                {
                    Id = 2,
                    Title = "Title #2", 
                    Content = "Content #2", 
                    PublishDate = DateTime.Now.AddDays(-1)
                },
                new NewsItem()
                {
                    Id = 3,
                    Title = "Title #3", 
                    Content = "Content #3", 
                    PublishDate = DateTime.Now.AddDays(-2)
                }
            };

            repoMock
                .Setup(repo => repo.Find(It.IsAny<int>()))
                .Returns((int id) => news.FirstOrDefault(n => n.Id == id));
            repoMock
                .Setup(repo => repo.Delete(It.IsAny<NewsItem>()))
                .Callback((NewsItem item) => news.RemoveAt(item.Id - 1));

            var controller = new NewsController(repoMock.Object);
            this.SetupController(controller, "news");

            var result = controller.DeleteNewsItem(newsItemIdToDelete).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        private void SetupController(ApiController controller, string controllerName)
        {
            string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }
    }
}
