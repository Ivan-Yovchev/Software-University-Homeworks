using System;

public class Payment
{
    private string productName;
    private decimal price;

    public Payment(string productName, decimal price)
    {
        this.ProductName = productName;
        this.Price = price;
    }

    public string ProductName
    {
        get
        {
            return this.productName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Product Name cannot be null or empty");
            }
            else
            {
                this.productName = value;
            }
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Product Price cannot be zero or negative");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public override string ToString()
    {
        return string.Format("Product Name: {0}, Price: {1:N2}", this.ProductName, this.Price);
    }
}
