namespace BookShopSystem.WebApi.Models.ViewModels
{
    using BookShopSystem.Models;

    public class AuthorViewModel
    {
        public AuthorViewModel(Author author)
        {
            this.Id = author.Id;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}