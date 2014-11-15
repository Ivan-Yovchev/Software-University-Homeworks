using System;
class NewHouse
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int roofSpace = n / 2;

        for (int i = 0; i < n/2; i++)
        {
            string space = new string('-', roofSpace);
            string roof = new string('*', n - (2 * roofSpace));

            Console.WriteLine("{0}{1}{0}",space,roof);
            roofSpace --;
        }

        string ledge = new string('*', n);
        Console.WriteLine(ledge);

        for (int i = 0; i < n; i++)
        {
            string house = new string('*', n - 2);
            Console.WriteLine("|{0}|",house);
        }
    }
}

