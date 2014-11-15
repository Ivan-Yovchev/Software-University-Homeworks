using System;

class CrossingSequences
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int number = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        if(number == a || number == b || number == c)
        {
            Console.WriteLine(number);
        }
        else
        {
            int d = a + b + c;
            int multiplication = 1;
            int counter = 0;

            while(true)
            {
                if(number == d || number == a)
                {
                    Console.WriteLine(number);
                    break;
                }
                else if(number < d)
                {
                    number += step * multiplication;
                    counter++;

                    if(counter == 2)
                    {
                        multiplication++;
                        counter = 0;
                    }
                }
                else if(number > d)
                {
                    a = b;
                    b = c;
                    c = d;
                    d = a + b + c;
                }

                // break loop if there is no output
                if(number > 1000000 || d > 1000000)
                {
                    Console.WriteLine("No");
                    break;
                }
            }
        }
    }
}

