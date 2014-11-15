using System;
class WineGlass
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int dots = 0;
        int asterix = n - 2;

        // top part
        for (int i = 0; i < n / 2; i++)
        {
            string wine = new string('*', asterix - (dots * 2));
            string outside = new string('.', dots);

            Console.WriteLine("{0}\\{1}/{0}", outside, wine);

            dots += 1;
        }

        //stem
        dots -= 1;
        if (n < 12)
        {
            for (int i = 0; i < (n / 2) - 1; i++)
            {
                string outside = new string('.', dots);
                Console.WriteLine("{0}||{0}", outside);
            }
        }
        else if (n >= 12)
        {
            for (int i = 0; i < (n / 2) - 2; i++)
            {
                string outside = new string('.', dots);
                Console.WriteLine("{0}||{0}", outside);
            }
        }

        // bottom part
        string bottom = new string('-', n);
        if (n < 12)
        {
            Console.WriteLine(bottom);
        }
        else if (n >= 12)
        {
            Console.WriteLine(bottom);
            Console.WriteLine(bottom);
        }
    }
}
