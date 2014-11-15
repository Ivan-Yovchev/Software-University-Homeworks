using System;

class MatrixOfPalindromes
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine().Split(' ');
        int rows = int.Parse(numbers[0]);
        int cols = int.Parse(numbers[1]);

        for (char i = 'a'; i < 'a' + rows; i++)
        {
            for (char j = i; j < i + cols; j++)
            {
                Console.Write("{0}{1}{0} ", i, j);
            }
            Console.WriteLine();
        }
    }
}

