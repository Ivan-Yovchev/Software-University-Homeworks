namespace BookShopSystem.WebApi.Models.ViewModels
{
    using System;
    using BookShopSystem.Models;

    public class PurchaseViewModel
    {
        public PurchaseViewModel(Purchase purchase)
        {
            this.BookTitle = purchase.Book.Title;
            this.DateOfPurchase = purchase.DateOfPurchase;
            this.Price = purchase.Price;
            this.IsRecalled = purchase.IsRecalled;
        }

        public string BookTitle { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public decimal Price { get; set; }

        public bool IsRecalled { get; set; }
    }
}