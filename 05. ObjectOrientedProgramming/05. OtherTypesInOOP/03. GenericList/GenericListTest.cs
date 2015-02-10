using System;

class GenericListTest
{
    static void Main()
    {
        GenericList<int> list = new GenericList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        Console.WriteLine(list);

        list.InsertAt(7, 66);
        Console.WriteLine(list);

        list.Clear();
        Console.WriteLine(list);
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        Console.WriteLine(list);
        list.InsertAt(3, 66);
        Console.WriteLine(list);

        Console.WriteLine(list.FindIndex(3));
        Console.WriteLine(list.HasValue(66));

        list.RemoveAt(3);
        Console.WriteLine(list);
        Console.WriteLine(list.HasValue(66));

        Console.WriteLine(list.Min());
        Console.WriteLine(list.Max());

        Console.WriteLine();
        var allAttributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), false);
        Console.WriteLine("Version: " + allAttributes[0]);
    }
}
