namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using OnlineShop.Models;

    [Authorize]
    public class AdsController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/ads")]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads
                .Where(a => a.Status == AdStatus.Open)
                .OrderByDescending(a => a.Type.Index)
                .ThenByDescending(a => a.PostedOn)
                .Select(AdsViewModel.Create);

            return this.Ok(ads);
        }

        [HttpPost]
        [Route("api/ads")]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var adType = this.Data.AdTypes.Find(model.TypeId);
            if (adType == null)
            {
                return this.BadRequest("No ad type with id " + model.TypeId);
            }

            if (!model.Categories.Any() || model.Categories.Count() > 3)
            {
                return this.BadRequest("Categories must be between 1 and 3");
            }

            var categories = new HashSet<Category>();
            foreach (var categoryId in model.Categories)
            {
                var category = this.Data.Categories.Find(categoryId);
                if (category == null)
                {
                    return this.BadRequest("No category with id " + categoryId);
                }

                categories.Add(category);
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PostedOn = DateTime.Now,
                Status = AdStatus.Open,
                OwnerId = userId,
                TypeId = model.TypeId,
                Categories = categories
            };
            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads
                .Where(a => a.Id == ad.Id)
                .Select(AdsViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        [HttpPut]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.Find(id);
            if (ad == null)
            {
                return this.BadRequest("No ad with id " + id);
            }

            string userId = this.User.Identity.GetUserId();
            if (ad.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}