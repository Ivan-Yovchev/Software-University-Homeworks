namespace BookShopSystem.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using Data;
    using Models.ViewModels;

    public class UsersController : ApiController
    {
        private BookShopContext db = new BookShopContext();

        [EnableQuery]
        [HttpGet]
        [Route("api/user/{username}/purchases")]
        public IQueryable<PurchaseViewModel> GetUserPurchases(string username)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return new List<PurchaseViewModel>().AsQueryable();
            }

            var userPurchases = user.Purchases.ToList();
            var purchases = new List<PurchaseViewModel>();
            foreach (var purchase in userPurchases)
            {
                purchases.Add(new PurchaseViewModel(purchase));
            }

            return purchases.AsQueryable();
        }
    }
}