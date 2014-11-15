using System;

class FloatOrDouble
{
    static void Main(string[] args)
    {
        double doubleNum = 34.567839023d;
        float floatNum = 12.345f;
        Console.WriteLine(doubleNum + " is a double type");
        Console.WriteLine(floatNum + " is a float type");

        doubleNum = 8923.1234857d;
        floatNum = 3456.091f;
        Console.WriteLine(doubleNum + " is a double type");
        Console.WriteLine(floatNum + " is a float type");
    }
}

