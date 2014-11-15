using System;

class OddEvenElements
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        string input = Console.ReadLine();
        string[] inputLine = input.Split(' ');
        decimal evenMax = decimal.MinValue, oddMax = decimal.MinValue;
        decimal evenMin = decimal.MaxValue, oddMin = decimal.MaxValue;
        decimal evenSum = 0, oddSum = 0;

        if(input == "")
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else if(inputLine.Length == 1)
        {
            Console.Write("OddSum={0}, OddMin={0}, OddMax={0}, ", Convert.ToDouble(inputLine[0]));
            Console.WriteLine("EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else
        {
            for (int i = 0; i < inputLine.Length; i++)
            {
                decimal Temp = Convert.ToDecimal(inputLine[i]);

                // number is odd
                if (i % 2 == 0)
                {
                    oddSum += Temp;
                    //check if number is greater than max
                    if (Temp > oddMax)
                    {
                        oddMax = Temp;
                    }
                    //check if number is smaller than min
                    if (Temp < oddMin)
                    {
                        oddMin = Temp;
                    }
                }
                //number is even
                else if (i % 2 != 0)
                {
                    evenSum += Temp;
                    //check if number is greater than max
                    if(Temp > evenMax)
                    {
                        evenMax = Temp;
                    }
                    //check if number is smaller than min
                    if(Temp < evenMin)
                    {
                        evenMin = Temp;
                    }
                }
            }

            // output result
            Console.Write("OddSum={0}, OddMin={1}, OddMax={2}, ", (double)oddSum, (double)oddMin, (double)oddMax);
            Console.WriteLine("EvenSum={0}, EvenMin={1}, EvenMax={2}", (double)evenSum, (double)evenMin, (double)evenMax);
        }
    }
}

