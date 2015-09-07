namespace BookShopSystem.WebApi.Models.ViewModels
{
    using BookShopSystem.Models;

    public class BookViewModelShort
    {
        public BookViewModelShort(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
        }

        public string Title { get; set; }

        public int Id { get; set; }
    }
}