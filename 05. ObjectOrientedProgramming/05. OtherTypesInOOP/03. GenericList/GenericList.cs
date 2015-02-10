using System;

[Version(1, 5)]
public class GenericList<T> where T : IComparable
{
    private const int DefaultSize = 16;

    private T[] elements;
    private int size, count = 0;

    public GenericList(int size = DefaultSize)
    {
        elements = new T[size];
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public int Size
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The size of the GenericList cannot be zero or negative");
            }
            else
            {
                this.size = value;
            }
        }
    }

    public void Add(T element)
    {
        if (count >= elements.Length)
        {
            T[] copyElements = this.elements;
            this.elements = new T[2 * this.elements.Length];
            Array.Copy(copyElements, 0, this.elements, 0, copyElements.Length);

            this.elements[count] = element;
            count++;
        }
        else
        {
            this.elements[count] = element;
            count++;
        }
    }

    public T AccessAt(int index)
    {
        return this.elements[index];
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < count; i++)
        {
            if (i + 1 < elements.Length)
            {
                elements[i] = elements[i + 1];
            }
            count--;
        }
    }

    public void InsertAt(int index, T element)
    {
        if (index >= count)
        {
            throw new IndexOutOfRangeException("Index is out of range");
        }
        else
        {
            T lastElement = this.elements[count - 1];

            for (int i = count - 1; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
            Add(lastElement);
        }
    }

    public void Clear()
    {
        this.count = 0;
    }

    public int FindIndex(T element)
    {
        int resultIndex = -1;

        for (int i = 0; i < count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                resultIndex = i;
                break;
            }
        }

        return resultIndex;
    }

    public bool HasValue(T element)
    {
        bool hasElement = false;

        for (int i = 0; i < count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                hasElement = true;
                break;
            }
        }

        return hasElement;
    }

    public T Max()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("The list is Empty");
        }

        T max = this.elements[0];

        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(max) > 0)
            {
                max = elements[i];
            }
        }

        return max;
    }

    public T Min()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("The list is Empty");
        }

        T min = this.elements[0];

        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(min) < 0)
            {
                min = elements[i];
            }
        }

        return min;
    }

    public T this[int index]
    {
        get
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                return this.elements[index];
            }
        }
    }

    public override string ToString()
    {
        string result = "[";

        for (int i = 0; i < this.count; i++)
        {
            if (i == 0)
            {
                result += this.elements[i];
            }
            else
            {
                result += ", " + this.elements[i];
            }
        }

        return result + "]";
    }
}
