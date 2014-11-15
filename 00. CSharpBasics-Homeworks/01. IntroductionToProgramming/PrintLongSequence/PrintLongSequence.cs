using System;

class PrintLongSequence
{
    static void Main(string[] args)
    {
        for (int i = 2; i < 1002; i++)
        {
            // Print Number in Sequence
            if (i % 2 == 0)
            {
                Console.Write(i);
            }
            else if (i % 2 != 0)
            {
                Console.Write(-i);
            }

            //check for a comma
            if (i < 1001 && i % 10 !=0)
            {
                Console.Write(", ");
            }
            else if (i < 1001 && i % 10 == 0)
            {
                Console.WriteLine(",");
            }
            else if(i == 1001)
            {
                Console.WriteLine();
            }

        }
    }
}

