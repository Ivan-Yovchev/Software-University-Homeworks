using System;

class PrintSequence
{
    static void Main(string[] args)
    {
        for (int i = 2; i < 12; i++)
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
            if(i<11)
            {
                Console.Write(", ");
            }
            else if(i == 11)
            {
                Console.WriteLine();
            }

        }
    }
}

