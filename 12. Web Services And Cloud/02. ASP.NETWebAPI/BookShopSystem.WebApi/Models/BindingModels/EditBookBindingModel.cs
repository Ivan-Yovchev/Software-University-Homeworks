namespace BookShopSystem.WebApi.Models.BindingModels
{
    using System;
    using BookShopSystem.Models;
    using System.ComponentModel.DataAnnotations;

    public class EditBookBindingModel
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

        [Required]
        [Display(Name = "AuthorId")]
        public int AuthorId { get; set; }
    }
}