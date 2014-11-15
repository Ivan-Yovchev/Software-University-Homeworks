using System;

class Arrow
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int WholeWidth = (2 * n) - 1;

        // make top part
        int outside = (WholeWidth - n) / 2;
        string top = new string('#', n);
        string Dots = new string('.', outside);
        Console.WriteLine("{0}{1}{0}", Dots, top);

        // make body
        int inside = n - 2;
        string insideDots = new string('.', inside);
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", Dots, insideDots);
        }

        // make the top of the head
        outside = (WholeWidth - inside) / 2;
        string BeginHead = new string('#', outside);
        Console.WriteLine("{0}{1}{0}", BeginHead, insideDots);

        //make head
        outside = 1;
        inside = (WholeWidth - 2) - (2 * outside);
        for (int i = 0; i < n - 2; i++)
        {
            inside = (WholeWidth - 2) - (2 * outside);

            insideDots = new string('.', inside);
            Dots = new string('.', outside);

            outside++;

            Console.WriteLine("{0}#{1}#{0}", Dots, insideDots);
        }

        //final line
        Dots = new string('.', (WholeWidth - 1) / 2);
        Console.WriteLine("{0}#{0}", Dots);
    }
}
