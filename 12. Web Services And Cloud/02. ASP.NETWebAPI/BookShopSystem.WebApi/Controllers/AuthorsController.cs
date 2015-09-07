namespace BookShopSystem.WebApi.Controllers
{
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
    public class AuthorsController : ApiController
    {
        private readonly BookShopContext db = new BookShopContext();

        // GET: api/authors/{id}
        [HttpGet]
        [Route("authors/{id}")]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = db.Authors.Find(id);
            if (author == null)
            {
                return this.BadRequest("No author with id " + id);
            }

            return this.Ok(new AuthorViewModel(author));
        }

        // POST: api/authors
        [HttpPost]
        [Route("authors")]
        public IHttpActionResult AddAuthor([FromBody]AddAuthorBindingModel addAuthor)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var author = new Author()
            {
                FirstName = addAuthor.FirstName,
                LastName = addAuthor.LastName
            };

            db.Authors.Add(author);
            db.SaveChanges();

            return this.Ok(new AuthorViewModel(author));
        }

        // GET: api/authors/{id}/books
        [EnableQuery]
        [HttpGet]
        [Route("authors/{id}/books")]
        public IQueryable<AuthorBookViewModel> GetAuthorBooks(int id)
        {
            var author = db.Authors.Find(id);
            if (author == null)
            {
                return Enumerable.Empty<AuthorBookViewModel>().AsQueryable();
            }

            var authorBooks = author.Books.ToList();
            var authorBooksViewModel = new List<AuthorBookViewModel>();
            foreach (var book in authorBooks)
            {
                authorBooksViewModel.Add(new AuthorBookViewModel(book));
            }

            return authorBooksViewModel.AsQueryable();
        } 
    }
}