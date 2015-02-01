using System;

class Customer : Person, ICustomer
{
    private decimal purchaseAmount;

    public Customer(string id, string firstName, string lastName, decimal purchaseAmount)
        : base(id, firstName, lastName)
    {
        this.PurchaseAmount = purchaseAmount;
    }

    public decimal PurchaseAmount
    {
        get { return this.purchaseAmount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Purchase amount cannot be a zero or negative number");
            }
            this.purchaseAmount = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + ", Purchase Amount: " + this.PurchaseAmount;
    }
}
