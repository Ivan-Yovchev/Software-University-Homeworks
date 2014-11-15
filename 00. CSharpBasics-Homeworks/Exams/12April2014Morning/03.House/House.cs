using System;

class House
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string top = new string('.', n / 2);
        Console.WriteLine("{0}*{0}", top);

        int inside = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            string roof = new string('.', inside);
            int outside = (n - 2 - inside) / 2;
            string outsideRoof = new string('.', outside);
            Console.WriteLine("{0}*{1}*{0}", outsideRoof, roof);

            inside += 2;
        }

        string lowerRoof = new string('*', n);
        Console.WriteLine(lowerRoof);

        int outsideSpace = n / 4;
        int insideSpace = n - 2 - (outsideSpace * 2);

        for (int i = 0; i < n / 2 - 1; i++)
        {
            string spaceOut = new string('.', outsideSpace);
            string spaceIn = new string('.', insideSpace);
            Console.WriteLine("{0}*{1}*{0}", spaceOut, spaceIn);
        }

        int lastLine = n - (2 * outsideSpace);
        string SpaceOut = new string('.', outsideSpace);
        string HouseBase = new string('*', lastLine);
        Console.WriteLine("{0}{1}{0}", SpaceOut, HouseBase);
    }
}
