namespace BookShopSystem.WebApi.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BookShopSystem.Models;

    public class NewBookBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Copies")]
        public int Copies { get; set; }

        [Required]
        [Display(Name = "Edition")]
        public EditionType Edition { get; set; }

        [Required]
        [Display(Name = "Age Restriction")]
        public AgeRestriction AgeRestriction { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Categories")]
        public string Categories { get; set; }
    }
}