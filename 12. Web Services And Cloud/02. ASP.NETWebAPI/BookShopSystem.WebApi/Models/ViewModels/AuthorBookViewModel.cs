namespace BookShopSystem.WebApi.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using BookShopSystem.Models;

    public class AuthorBookViewModel
    {
        public AuthorBookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.Edition = book.Edition;
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.ReleaseDate = book.ReleaseDate;
            this.AgeRestriction = book.AgeRestriction;
            this.Categories = new List<string>();
            foreach (var category in book.Categories)
            {
                this.Categories.Add(category.Name);
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType Edition { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}