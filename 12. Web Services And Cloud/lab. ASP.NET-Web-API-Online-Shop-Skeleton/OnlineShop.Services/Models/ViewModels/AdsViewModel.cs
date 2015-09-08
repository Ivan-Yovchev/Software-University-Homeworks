namespace OnlineShop.Services.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using OnlineShop.Models;

    public class AdsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime PostedOn { get; set; }

        public OwnerViewModel Owner { get; set; }

        public string Type { get; set; }

        public IEnumerable<CategoriesViewModel> Categories { get; set; }

        public static Expression<Func<Ad, AdsViewModel>> Create
        {
            get
            {
                return ad => new AdsViewModel
                {
                    Id = ad.Id,
                    Name = ad.Name,
                    Description = ad.Description,
                    Price = ad.Price,
                    Owner = new OwnerViewModel
                    {
                        Id = ad.OwnerId,
                        Username = ad.Owner.UserName
                    },
                    Type = ad.Type.Name,
                    PostedOn = ad.PostedOn,
                    Categories = ad.Categories
                    .Select(c => new CategoriesViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                };
            }
        }
    }
}