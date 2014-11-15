using System;

class MagicCarNumbers
{
    static void Main(string[] args)
    {
        int weight = int.Parse(Console.ReadLine());
        int count = 0;
        int countCase1 = 0;

        char[] symbols = new char[] { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };

        for (int a = 0; a < 10; a++)
        {
            for (int b = 0; b < 10; b++)
            {
                for (int symbol1 = 0; symbol1 < 10; symbol1++)
                {
                    for (int symbol2 = 0; symbol2 < 10; symbol2++)
                    {
                        //get lasst two symbols weight
                        string lastTwo = "" + symbols[symbol1] + symbols[symbol2];
                        int symbolsWeight = Getwieght(lastTwo);

                        // check 4 cases for the a,b arangement ( aaaa, abbb, aaab, aabb)
                        int case1 = 4 * a;
                        int case2 = (3 * a) + b;
                        int case3 = (2 * a) + (2 * b);
                        int case4 = a + (3 * b);

                        if (symbolsWeight + case1 == weight)
                        {
                            countCase1++;
                        }
                        else if (symbolsWeight + case2 == weight)
                        {
                            count++;
                            // Console.WriteLine("case2: a: {0} b: {1} symbols: {2}", a, b, lastTwo);
                        }
                        else if (symbolsWeight + case3 == weight)
                        {
                            count += 3;
                            //Console.WriteLine("case3: a: {0} b: {1} symbols: {2}", a, b, lastTwo);
                        }
                        else if (symbolsWeight + case4 == weight)
                        {
                            count++;
                            //Console.WriteLine("case4: a: {0} b: {1} symbols: {2}", a, b, lastTwo);
                        }
                    }
                }
            }
        }
        Console.WriteLine(count + (countCase1 / 10));
    }

    private static int Getwieght(string lastTwo)
    {
        int weigth = 0;
        for (int i = 0; i < lastTwo.Length; i++)
        {
            switch (lastTwo[i])
            {
                case 'A': weigth += 10; break;
                case 'B': weigth += 20; break;
                case 'C': weigth += 30; break;
                case 'E': weigth += 50; break;
                case 'H': weigth += 80; break;
                case 'K': weigth += 110; break;
                case 'M': weigth += 130; break;
                case 'P': weigth += 160; break;
                case 'T': weigth += 200; break;
                case 'X': weigth += 240; break;
            }
        }
        weigth += 40;
        return weigth;
    }
}
