namespace BookShopSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;

    class BookShopMain
    {
        static void Main()
        {
            var context = new BookShopContext();
            var count = context.Categories.Count();
            Console.WriteLine(count);
        }
    }
}
