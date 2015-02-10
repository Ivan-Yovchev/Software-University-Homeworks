using System;

struct Fraction
{
    private long numerator, denominator;

    public Fraction(long numerator, long denominator)
        : this()
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public long Numerator
    {
        get
        {
            return this.numerator;
        }
        set
        {
            this.numerator = value;
        }
    }

    public long Denominator
    {
        get
        {
            return this.denominator;
        }
        set
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero");
            }
            else
            {
                this.denominator = value;
            }
        }
    }

    public static Fraction operator +(Fraction frac1, Fraction frac2)
    {
        long num = frac1.numerator * frac2.denominator + frac2.numerator * frac1.denominator;
        long denom = frac1.denominator * frac2.denominator;

        return new Fraction(num, denom);
    }

    public static Fraction operator -(Fraction frac1, Fraction frac2)
    {
        long num = frac1.numerator * frac2.denominator - frac2.numerator * frac1.denominator;
        long denom = frac1.denominator * frac2.denominator;

        return new Fraction(num, denom);
    }

    public override string ToString()
    {
        return string.Format("{0}", (decimal)this.Numerator / (decimal)this.Denominator);
    }
}
