namespace BookShopSystem.WebApi.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddCategoryBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}