using System;

class NullValuesArithmetic
{
    static void Main(string[] args)
    {
        int? intNum = null;
        double? doubleNum = null;
        Console.WriteLine("{0} {1}",intNum,doubleNum);

        intNum += 20;
        Console.WriteLine(intNum);

        doubleNum += null;
        Console.WriteLine(doubleNum);
    }
}

