using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            PrintArray(Spiral(n));
        }

        public static int[,] Spiral(int n)
        {
            int[,] result = new int[n, n];

            int pos = 1;
            int count = n;
            int value = -n;
            int sum = -1;

            do
            {
                value = -1 * value / n;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    result[sum / n, sum % n] = pos;
                    pos++;
                }
                value *= n;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    result[sum / n, sum % n] = pos;
                    pos++;
                }
            } while (count > 0);

            return result;
        }


        // Method to print arrays, pads numbers so they line up in columns
        public static void PrintArray(int[,] array)
        {
            int n = (array.GetLength(0) * array.GetLength(1) - 1).ToString().Length + 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j].ToString().PadRight(n, ' '));
                }
                Console.WriteLine();
            }
        }
    }
}
