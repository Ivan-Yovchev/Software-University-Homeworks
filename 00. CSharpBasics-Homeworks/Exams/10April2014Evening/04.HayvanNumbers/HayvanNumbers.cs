using System;

class HayvanNumbers
{
    static void Main(string[] args)
    {
        int sum = int.Parse(Console.ReadLine());
        int difference = int.Parse(Console.ReadLine());

        bool output = false;

        for (int a = 5; a < 10; a++)
        {
            for (int b = 5; b < 10; b++)
            {
                for (int c = 5; c < 10; c++)
                {
                    for (int d = 5; d < 10; d++)
                    {
                        for (int e = 5; e < 10; e++)
                        {
                            for (int f = 5; f < 10; f++)
                            {
                                for (int g = 5; g < 10; g++)
                                {
                                    for (int h = 5; h < 10; h++)
                                    {
                                        for (int i = 5; i < 10; i++)
                                        {
                                            int tempSum = a + b + c + d + e + f + g + h + i;
                                            if (tempSum == sum)
                                            {
                                                int diff1 = g * 100 + h * 10 + i;
                                                int diff2 = d * 100 + e * 10 + f;
                                                if ((diff1 - diff2) == difference)
                                                {
                                                    int diff3 = a * 100 + b * 10 + c;
                                                    if ((diff2 - diff3) == difference)
                                                    {
                                                        Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", a, b, c, d, e, f, g, h, i);
                                                        output = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (output == false)
        {
            Console.WriteLine("No");
        }
    }
}
