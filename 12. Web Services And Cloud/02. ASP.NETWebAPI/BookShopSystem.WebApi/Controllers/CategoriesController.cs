namespace BookShopSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using Data;
    using BookShopSystem.Models;
    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize]
    [RoutePrefix("api")]
    public class CategoriesController : ApiController
    {
        private readonly BookShopContext db = new BookShopContext();

        // GET: api/categories
        [EnableQuery]
        [Route("categories")]
        [HttpGet]
        public IQueryable<CategoryViewModel> GetAllCategories()
        {
            var categories = db.Categories.ToList();
            var categoryViewModels = categories.Select(category => new CategoryViewModel(category)).ToList();

            return categoryViewModels.AsQueryable();
        }

        // GET: api/categories/{id}
        [HttpGet]
        [Route("categories/{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(new CategoryViewModel(category));
        }

        // PUT: api/categories/{id}
        [HttpPut]
        [Route("categories/{id}")]
        public IHttpActionResult EditCategory(int id, [FromBody]EditCategoryBindingModel editCategory)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var foundCategory = db.Categories.Find(id);
            if (foundCategory == null)
            {
                return this.BadRequest("Invalid Category ID");
            }

            bool hasDuplicateName = false;
            foreach (var category in db.Categories)
            {
                if (category.Name == editCategory.Name)
                {
                    hasDuplicateName = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (hasDuplicateName == true)
            {
                return this.BadRequest("There is already a category with the name " + editCategory.Name);
            }

            foundCategory.Name = editCategory.Name;
            db.SaveChanges();

            return this.Ok(new CategoryViewModel(foundCategory));
        }

        // POST: api/categories
        [HttpPost]
        [Route("categories")]
        public IHttpActionResult AddCategory([FromBody]AddCategoryBindingModel addCategory)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            bool hasDuplicateName = false;
            foreach (var category in db.Categories)
            {
                if (addCategory.Name == category.Name)
                {
                    hasDuplicateName = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (hasDuplicateName == true)
            {
                return this.BadRequest("There is already a category with the name " + addCategory.Name);
            }

            var newCategory = new Category()
            {
                Name = addCategory.Name
            };

            db.Categories.Add(newCategory);
            db.SaveChanges();

            return this.Ok(new CategoryViewModel(newCategory));
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        [Route("categories/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(new CategoryViewModel(category));
        }
    }
}