using System;

class FruitMarket
{
    static void Main(string[] args)
    {

        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        double price = 0;

        //input
        string day = Console.ReadLine();
        for (int i = 0; i < 3; i++)
        {
            double quantity = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();

            if (day == "Tuesday")
            {
                if (product == "banana" || product == "orange" || product == "apple")
                {
                    price += quantity * (getPrice(product) - getPrice(product) / 5);
                }
                else
                {
                    price += quantity * getPrice(product);
                }
            }
            else if (day == "Wednesday")
            {
                if (product == "cucumber" || product == "tomato")
                {
                    price += quantity * (getPrice(product) - getPrice(product) / 10);
                }
                else
                {
                    price += quantity * getPrice(product);
                }
            }
            else if (day == "Thursday")
            {
                if (product == "banana")
                {
                    price += quantity * (getPrice(product) - (getPrice(product) * 3) / 10);
                }
                else
                {
                    price += quantity * getPrice(product);
                }
            }
            else if (day == "Friday")
            {
                price += quantity * (getPrice(product) - getPrice(product) / 10);
            }
            else if (day == "Sunday")
            {
                price += quantity * (getPrice(product) - getPrice(product) / 20);
            }
            else
            {
                price += quantity * getPrice(product);
            }

        }


        Console.WriteLine("{0:F2}", price);


    }

    private static double getPrice(string product)
    {
        double price = 0;

        switch (product)
        {
            case "banana": price = 1.80; break;
            case "cucumber": price = 2.75; break;
            case "tomato": price = 3.20; break;
            case "orange": price = 1.60; break;
            case "apple": price = 0.86; break;
        }

        return price;
    }
}
