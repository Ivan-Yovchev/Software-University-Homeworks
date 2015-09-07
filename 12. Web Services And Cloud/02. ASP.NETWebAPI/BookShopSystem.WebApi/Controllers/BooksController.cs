namespace BookShopSystem.WebApi.Controllers
{
    using System;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using Data;
    using BookShopSystem.Models;
    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize]
    [RoutePrefix("api")]
    public class BooksController : ApiController
    {
        private BookShopContext db = new BookShopContext();

        // GET: api/books/{id}
        [HttpGet]
        [Route("books/{id}")]
        public IHttpActionResult GetBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("No book with Id " + id);
            }

            return this.Ok(new BookViewModel(book));
        }

        // GET: api/books?search={searchWord}
        [EnableQuery]
        [HttpGet]
        [Route("books")]
        public IQueryable<BookViewModelShort> SearchBooks(string searchWord)
        {
            var books = db.Books
                .Where(b => b.Title.Contains(searchWord))
                .OrderBy(b => b.Title)
                .Take(10)
                .ToList();
            var searchedBooks = new List<BookViewModelShort>();
            foreach (var book in books)
            {
                searchedBooks.Add(new BookViewModelShort(book));
            }

            return searchedBooks.AsQueryable();
        }

        // GET: api/books/{id}
        [HttpPut]
        [Route("books/{id}")]
        public IHttpActionResult EditBook(int id, [FromBody]EditBookBindingModel editBook)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var book = db.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("No book with Id " + id);
            }

            var author = db.Authors.Find(editBook.AuthorId);
            if (author == null)
            {
                return this.BadRequest("No Auhtor with Id " + editBook.AuthorId);
            }

            book.Title = editBook.Title;
            book.Description = editBook.Description;
            book.Price = editBook.Price;
            book.Copies = editBook.Copies;
            book.Edition = editBook.Edition;
            book.AgeRestriction = editBook.AgeRestriction;
            book.ReleaseDate = editBook.ReleaseDate;
            book.AuthorId = editBook.AuthorId;
            book.Author = author;
            db.SaveChanges();

            return this.Ok(new BookViewModel(book));
        }

        // DELETE: api/books/{id}
        [HttpDelete]
        [Route("books/{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("No book with Id " + id);
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return this.Ok(new BookViewModel(book));
        }

        // POST: api/books
        [HttpPost]
        [Route("books")]
        public IHttpActionResult PostNewBook([FromBody]NewBookBindingModel newBook)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var book = new Book()
            {
                Title = newBook.Title,
                Description = newBook.Description,
                Price = newBook.Price,
                Copies = newBook.Copies,
                Edition = newBook.Edition,
                AgeRestriction = newBook.AgeRestriction,
                ReleaseDate = newBook.ReleaseDate
            };

            if (newBook.Categories != null)
            {
                var newBookCategories = newBook.Categories.Split(new[] { ',' });
                var categories = db.Categories.Select(c => c.Name).ToList();
                foreach (var category in newBookCategories)
                {
                    if (categories.Contains(category))
                    {
                        book.Categories.Add(db.Categories.FirstOrDefault(c => c.Name == category));
                    }
                    else
                    {
                        var newCategory = new Category()
                        {
                            Name = category
                        };
                        db.Categories.Add(newCategory);
                        db.SaveChanges();
                        book.Categories.Add(newCategory);
                    }
                }
            }
            db.Books.Add(book);
            db.SaveChanges();

            return this.Ok(new BookViewModel(book));
        }

        // PUT: api/books/buy/{id}
        [HttpPut]
        [Route("books/buy/{id}")]
        public IHttpActionResult CreateNewPurchase(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("No book with id " + id);
            }

            if (book.Copies <= 0)
            {
                return this.BadRequest("Not enough copies from selected book");
            }

            var user = db.Users.Find(User.Identity.GetUserId());
            var purchase = new Purchase()
            {
                ApplicationUserId = user.Id,
                BookId = book.Id,
                DateOfPurchase = DateTime.Now,
                Price = book.Price,
                IsRecalled = false
            };

            user.Purchases.Add(purchase);
            book.Copies--;
            db.SaveChanges();

            return this.Ok(new PurchaseViewModel(purchase));
        }

        // PUT: api/books/recall/{id}
        [HttpPut]
        [Route("books/recall/{id}")]
        public IHttpActionResult RecallPurchase(int id)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var purchase = user.Purchases.FirstOrDefault(p => p.BookId == id);
            if (purchase == null)
            {
                return this.BadRequest("No purchase with book with id " + id + " for currently logged user");
            }

            if ((DateTime.Now - purchase.DateOfPurchase).TotalDays >= 30)
            {
                return this.BadRequest("Cannot recall a purchase after more than 30 days");
            }

            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.BadRequest("No book with id " + id + " in the database");
            }

            book.Copies++;
            purchase.IsRecalled = true;
            db.SaveChanges();

            return this.Ok(new PurchaseViewModel(purchase));
        }
    }
}