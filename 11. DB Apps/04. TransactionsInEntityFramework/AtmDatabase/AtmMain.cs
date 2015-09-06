using System;
using System.Linq;
using System.Transactions;

namespace AtmDatabase
{
    class AtmMain
    {
        static void Main()
        {
            var db = new ATMEntities();
            using (var scope = new TransactionScope())
            {
                Console.Write("Enter Card Number: ");
                var cardNumber = Console.ReadLine();

                Console.Write("Enter PIN: ");
                var pin = Console.ReadLine();

                Console.Write("Amount: ");
                var money = Decimal.Parse(Console.ReadLine());

                if (cardNumber.Length < 10 || cardNumber.Length > 10 ||
                    !db.CardAccounts.Any(c => c.CardNumber == cardNumber))
                {
                    throw new ArgumentException("Invalid Card Number!");
                }

                if (pin.Length < 4 || pin.Length > 4 || !db.CardAccounts.Any(c => c.CardPIN == pin))
                {
                    throw new ArgumentException("Invalid PIN!");
                }

                var account = db.CardAccounts.FirstOrDefault(c => c.CardNumber == cardNumber && c.CardPIN == pin);
                if (account.CardCash < money)
                {
                    throw new ArgumentException("Not Enough Money In Account!");
                }

                account.CardCash = account.CardCash - money;
                db.SaveChanges();

                db.TransactionHistories.Add(new TransactionHistory()
                {
                    CardNumber = account.CardNumber,
                    TransactionDate = DateTime.Now,
                    Amount = money
                });
                db.SaveChanges();

                scope.Complete();
            }
        }
    }
}
