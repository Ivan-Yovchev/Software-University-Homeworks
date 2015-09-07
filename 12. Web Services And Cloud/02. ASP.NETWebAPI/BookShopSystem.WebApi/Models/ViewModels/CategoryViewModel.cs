namespace BookShopSystem.WebApi.Models.ViewModels
{
    using BookShopSystem.Models;

    public class CategoryViewModel
    {
        public CategoryViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}