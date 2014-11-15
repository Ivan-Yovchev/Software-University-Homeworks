using System;

class Eclipse
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // top side
        string top = new string('*', (2 * n - 2));
        string emptyBridge = new string(' ', n - 1);
        Console.WriteLine(" {0} {1} {0} ",top,emptyBridge);

        //middle section and lenses
        string lense = new string('/', (2 * n - 2));
        string bridge = new string('-', n - 1);
        for (int i = 0; i < n-2; i++)
        {
            if (i == (n - 2) / 2)
            {
                Console.WriteLine("*{0}*{1}*{0}*",lense,bridge);
            }
            else
            {
                Console.WriteLine("*{0}*{1}*{0}*",lense,emptyBridge);
            }
        }

        //bottom side
        Console.WriteLine(" {0} {1} {0} ", top, emptyBridge);
    }
}

