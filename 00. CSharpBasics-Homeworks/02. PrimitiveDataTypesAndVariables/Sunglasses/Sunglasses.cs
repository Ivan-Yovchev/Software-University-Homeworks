using System;

class Sunglasses
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int Lenght = 2*N;

        for (int i = 0; i < N; i++)
        {
            if (i == 0 || i == N - 1)
            {
                string frame = new String('*',Lenght);
                string space = new String(' ', N);
                Console.Write(frame);
                Console.Write(space);
                Console.Write(frame);
            }
            else if(i == (int)N/2)
            {
                string glass = new String('/', Lenght - 2);
                string connection = new String('|', N);
                Console.Write("*" + glass + "*");
                Console.Write(connection);
                Console.Write("*" + glass + "*");
            }
            else
            {
                string glass = new String('/', Lenght - 2);
                string space = new String(' ', N);
                Console.Write("*" + glass + "*");
                Console.Write(space);
                Console.Write("*" + glass + "*");
            }
            Console.WriteLine();
        }
    }
}

