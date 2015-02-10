using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public static class ExtensionMethods
{
    public static String Substring(this StringBuilder stringBuilder, int startIndex, int length)
    {
        String result = String.Empty;

        if (startIndex < 0 || startIndex >= stringBuilder.Length)
        {
            throw new ArgumentOutOfRangeException("Start Index is out of range");
        }
        else if (startIndex + length > stringBuilder.Length)
        {
            throw new ArgumentOutOfRangeException("Length is out of range");
        }
        else
        {
            for (int i = startIndex; i < startIndex + length; i++)
            {
                result += stringBuilder[i];
            }
        }

        return result;
    }

    public static void RemoveText(this StringBuilder stringBuilder, string text)
    {
        string builderToString = stringBuilder.ToString();
        if (builderToString.ToLower().Contains(text.ToLower()))
        {
            int index = builderToString.ToLower().IndexOf(text.ToLower());
            stringBuilder.Remove(index, text.Length);
        }
        else
        {
            throw new ArgumentException("No occurence found");
        }
    }

    public static void AppendAll<T>(this StringBuilder stringBuilder, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            stringBuilder.Append(item.ToString() + " ");
        }
    }
}
