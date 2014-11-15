using System;

class MagicStrings
{
    static void Main(string[] args)
    {
        int diff = int.Parse(Console.ReadLine());
        char[] symbols = { 'k', 'n', 'p', 's' };
        bool isOut = false;

        for (int a1 = 0; a1 < 4; a1++)
        {
            for (int a2 = 0; a2 < 4; a2++)
            {
                for (int a3 = 0; a3 < 4; a3++)
                {
                    for (int a4 = 0; a4 < 4; a4++)
                    {
                        string First = "" + symbols[a1] + symbols[a2] + symbols[a3] + symbols[a4];
                        int sum1 = CountWeight(First);

                        for (int b1 = 0; b1 < 4; b1++)
                        {
                            for (int b2 = 0; b2 < 4; b2++)
                            {
                                for (int b3 = 0; b3 < 4; b3++)
                                {
                                    for (int b4 = 0; b4 < 4; b4++)
                                    {
                                        string Second = "" + symbols[b1] + symbols[b2] + symbols[b3] + symbols[b4];
                                        int sum2 = CountWeight(Second);

                                        if (Math.Abs(sum1 - sum2) == diff)
                                        {
                                            Console.WriteLine(First + Second);
                                            isOut = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (isOut == false)
        {
            Console.WriteLine("No");
        }
    }

    private static int CountWeight(string str)
    {
        //weight('s') = 3; weight('n') = 4;  weight('k') = 1;  weight('p') = 5. 
        int sum = 0;
        foreach (var ch in str)
        {
            switch (ch)
            {
                case 'k': sum += 1; break;
                case 's': sum += 3; break;
                case 'n': sum += 4; break;
                case 'p': sum += 5; break;
            }
        }
        return sum;
    }
}
