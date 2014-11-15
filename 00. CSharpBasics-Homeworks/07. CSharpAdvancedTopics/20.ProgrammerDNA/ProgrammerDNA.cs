using System;

class ProgrammerDNA
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char symbol = char.Parse(Console.ReadLine());

        bool add = false;
        bool startOver = false;
        const int length = 7;
        int dotsLength = 3;

        for (int i = 0; i < n; i++)
        {
            string letters = "";

            for (int j = 0; j < length - (2 * dotsLength); j++)
            {
                letters += symbol;

                //change symbol
                if (symbol == 'G')
                {
                    symbol = 'A';
                }
                else
                {
                    symbol++;
                }
            }

            string dots = new string('.', dotsLength);
            Console.WriteLine("{0}{1}{0}",dots,letters);

            if(startOver == true)
            {
                dotsLength = 3;
                startOver = false;
            }
            else if(add == true)
            {
                dotsLength++;
                if(dotsLength == 3)
                {
                    add = false;
                    startOver = true;
                }
            }
            else if(add == false)
            {
                dotsLength--;
                if(dotsLength == 0)
                {
                    add = true;
                }
            }
        }
    }
}

