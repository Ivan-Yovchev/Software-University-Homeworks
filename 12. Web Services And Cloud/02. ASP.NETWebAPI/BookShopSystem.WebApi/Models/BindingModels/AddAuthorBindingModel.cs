namespace BookShopSystem.WebApi.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddAuthorBindingModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}