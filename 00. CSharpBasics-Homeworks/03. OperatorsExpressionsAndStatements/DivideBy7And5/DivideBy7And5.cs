using System;

class DivideBy7And5
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());
        bool Divided = false;

        if(Num % 5 == 0 && Num % 7 == 0 && Num != 0)
        {
            Divided = true;
        }

        Console.WriteLine(Divided);
    }
}

