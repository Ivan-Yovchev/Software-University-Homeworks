using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
{
    private StringBuilder totalString;

    public StringDisperser(params string[] strings)
    {
        this.TotalString = new StringBuilder();
        foreach (var str in strings)
        {
            this.TotalString.Append(str);
        }
    }

    public StringBuilder TotalString
    {
        get
        {
            return this.totalString;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("TotalString cannot be null or empty");
            }
            else
            {
                this.totalString = value;
            }
        }
    }

    public override string ToString()
    {
        return this.TotalString.ToString();
    }

    public override bool Equals(object obj)
    {
        StringDisperser stringDisperser = obj as StringDisperser;
        if (stringDisperser == null)
        {
            return false;
        }

        return this.TotalString.ToString().Equals(stringDisperser.TotalString.ToString());
    }

    public static bool operator ==(StringDisperser firstString, StringDisperser secondString)
    {
        return Object.Equals(firstString, secondString);
    }

    public static bool operator !=(StringDisperser firstString, StringDisperser secondString)
    {
        return !Object.Equals(firstString, secondString);
    }

    public override int GetHashCode()
    {
        return this.TotalString.GetHashCode();
    }

    public object Clone()
    {
        return new StringBuilder().Append(this.TotalString.ToString());
    }

    public int CompareTo(StringDisperser other)
    {
        return this.TotalString.ToString().CompareTo(other.TotalString.ToString());
    }

    public IEnumerator<char> GetEnumerator()
    {
        for (int i = 0; i < this.TotalString.Length; i++)
        {
            yield return this.TotalString[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
