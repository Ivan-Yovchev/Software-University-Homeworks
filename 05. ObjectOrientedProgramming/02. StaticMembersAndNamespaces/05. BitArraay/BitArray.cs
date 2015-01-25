using System;

class BitArray
{
    private int size = -1;
    private int[] bits;

    public BitArray(int size)
    {
        this.Size = size;
    }

    public int Size
    {
        get { return this.size; }
        set
        {
            if (this.size < 0)
            {
                if (value < 1 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("The size must be in the range [1...100 000]");
                }
                this.size = value;
                bits = new int[value];
            }
            else
            {
                throw new Exception("Cannot change BitArray Size");
            }
        }
    }

    public int this[int index]
    {
        get
        {
            if ((index >= 0) && (index < this.size))
            {
                if (bits[index] == 0)
                    return 0;
                else
                    return 1;
            }
            else
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Index {0} is invalid!", index));
            }
        }

        set
        {
            if ((index < 0) || (index > this.size - 1))
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Index {0} is invalid!", index));
            }
            if ((value < 0) || (value > 1))
            {
                throw new ArgumentException(String.Format(
                    "Value {0} is invalid!", value));
            }

            bits[index] = value;

        }
    }

    public override string ToString()
    {
        long result = 0;

        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] == 1)
            {
                result += (long)Math.Pow(2, i);
            }
        }

        return "" + result;
    }

}
