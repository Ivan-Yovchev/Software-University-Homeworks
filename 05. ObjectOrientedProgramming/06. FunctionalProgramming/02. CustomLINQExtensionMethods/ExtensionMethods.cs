using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ExtensionMethods
{
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        return collection.Where(num => !predicate(num));
    }

    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
    {
        var collectionAsList = collection.ToList();
        for (int i = 0; i < count - 1; i++)
        {
            collectionAsList.AddRange(collection.ToList());
        }

        return collectionAsList as IEnumerable<T>;
    }

    public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
    {
        List<string> results = new List<string>();

        foreach (var item in collection)
        {
            foreach (var suffix in suffixes)
            {
                if (item.EndsWith(suffix))
                {
                    results.Add(item);
                }
            }
        }

        return results as IEnumerable<string>;
    }
}
