namespace News.Repositories.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Data;
    using Models;
    using EntityFramework.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NewsRepositoryTests
    {
        [TestMethod]
        public void ListAllNewsItems_ShouldReturnAllNewsItems()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Title = "Test 1",
                    Content = "Content 1",
                    PublishDate = DateTime.Now
                },
                new NewsItem
                {
                    Title = "Test 2",
                    Content = "Content 2",
                    PublishDate = DateTime.Now.AddDays(-1)
                },
                new NewsItem
                {
                    Title = "Test 3",
                    Content = "Content 3",
                    PublishDate = DateTime.Now.AddDays(-2)
                }
            };

            foreach (var newsItem in news)
            {
                repo.Add(newsItem);
            }
            repo.SaveChanges();

            var newsFromRepository = repo.All();
            CollectionAssert.AreEquivalent(newsFromRepository.ToList(), news);
        }

        [TestMethod]
        public void CreateNewItem_ShouldAddToDbAndReturnNewsItem()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var newsItem = new NewsItem
            {
                Title = "Test Title",
                Content = "Test Content",
                PublishDate = DateTime.Now
            };

            var newsItemFromDb = repo.Add(newsItem);
            repo.SaveChanges();

            Assert.IsNotNull(newsItemFromDb);
            Assert.AreEqual(newsItemFromDb.Title, newsItem.Title);
            Assert.AreEqual(newsItemFromDb.Content, newsItem.Content);
            Assert.AreEqual(newsItemFromDb.PublishDate, newsItem.PublishDate);
            Assert.IsTrue(newsItemFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateNewItem_ShouldThrowExcpetionOnIncorrectData()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var newsItem = new NewsItem
            {
                Title = null,
                Content = null
            };
            repo.Add(newsItem);
            repo.SaveChanges();
        }

        [TestMethod]
        public void UpdateNewsItem_ShouldUpdateItemWithCorrectData()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var newsItem = new NewsItem
            {
                Title = "Test Title",
                Content = "Test Content",
                PublishDate = DateTime.Now
            };
            repo.Add(newsItem);
            repo.SaveChanges();

            var newsItemFromDb = repo.Find(newsItem.Id);
            newsItemFromDb.Title = "Updated Title";
            newsItemFromDb.Content = "Updated Content";
            repo.Update(newsItemFromDb);
            repo.SaveChanges();

            var updatedNewsItem = repo.Find(newsItem.Id);
            Assert.IsNotNull(updatedNewsItem);
            Assert.AreEqual(updatedNewsItem.Title, newsItemFromDb.Title);
            Assert.AreEqual(updatedNewsItem.Content, newsItemFromDb.Content);
            Assert.AreEqual(updatedNewsItem.PublishDate, newsItem.PublishDate);
            Assert.IsTrue(updatedNewsItem.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void UpdateNewsItem_ShouldThrowExceptionOnIncorrectData()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var newsItem = new NewsItem
            {
                Title = "Test Title",
                Content = "Test Content",
                PublishDate = DateTime.Now
            };
            repo.Add(newsItem);
            repo.SaveChanges();

            var newsItemFromDb = repo.Find(newsItem.Id);
            newsItemFromDb.Title = null;
            repo.Update(newsItemFromDb);
            repo.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void UpdateNewsItem_ShouldThrowExcpetionIfNonExistent()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Title = "Test 1",
                    Content = "Content 1",
                    PublishDate = DateTime.Now
                },
                new NewsItem
                {
                    Title = "Test 2",
                    Content = "Content 2",
                    PublishDate = DateTime.Now.AddDays(-1)
                },
                new NewsItem
                {
                    Title = "Test 3",
                    Content = "Content 3",
                    PublishDate = DateTime.Now.AddDays(-2)
                }
            };

            foreach (var newsItem in news)
            {
                repo.Add(newsItem);
            }
            repo.SaveChanges();

            var newsItemToUpdate = new NewsItem
            {
                Title = "Test 4",
                Content = "Content 4",
                PublishDate = DateTime.Now
            };
            repo.Update(newsItemToUpdate);
            repo.SaveChanges();
        }

        [TestMethod]
        public void DeleteNewsItem_ShouldDeleteItemIfExistent()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var firstNewsItem = new NewsItem
            {
                Title = "Test 1",
                Content = "Content 1",
                PublishDate = DateTime.Now
            };
            var secondNewsItem = new NewsItem
            {
                Title = "Test 2",
                Content = "Content 2",
                PublishDate = DateTime.Now.AddDays(-1)
            };
            var thirdNewsItem = new NewsItem
            {
                Title = "Test 3",
                Content = "Content 3",
                PublishDate = DateTime.Now.AddDays(-2)
            };
            var news = new List<NewsItem>
            {
                firstNewsItem,
                secondNewsItem,
                thirdNewsItem
            };

            foreach (var newsItem in news)
            {
                repo.Add(newsItem);
            }
            repo.SaveChanges();

            repo.Delete(secondNewsItem);
            repo.SaveChanges();

            var expectedResult = new List<NewsItem>
            {
                firstNewsItem,
                thirdNewsItem
            };
            var actualResult = repo.All();

            CollectionAssert.AreEquivalent(actualResult.ToList(), expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DeleteNewsItem_ShouldThrowExceptionIfNonExistent()
        {
            CleanDataBase();
            var repo = new NewsRepository(new NewsContext());
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Title = "Test 1",
                    Content = "Content 1",
                    PublishDate = DateTime.Now
                },
                new NewsItem
                {
                    Title = "Test 2",
                    Content = "Content 2",
                    PublishDate = DateTime.Now.AddDays(-1)
                },
                new NewsItem
                {
                    Title = "Test 3",
                    Content = "Content 3",
                    PublishDate = DateTime.Now.AddDays(-2)
                }
            };

            foreach (var newsItem in news)
            {
                repo.Add(newsItem);
            }
            repo.SaveChanges();

            var newsItemToDelete = new NewsItem
            {
                Title = "Test 4",
                Content = "Content 4",
                PublishDate = DateTime.Now
            };
            repo.Delete(newsItemToDelete);
            repo.SaveChanges();
        }

        private static void CleanDataBase()
        {
            var dbContext = new NewsContext();
            dbContext.News.Delete();
            dbContext.SaveChanges();
        }
    }
}
