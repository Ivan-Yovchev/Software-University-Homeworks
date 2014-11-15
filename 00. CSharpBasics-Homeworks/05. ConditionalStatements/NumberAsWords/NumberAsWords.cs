using System;


class NumberAsWords
{
    static void Main(string[] args)
    {
        int num;
        Console.Write("Enter number: ");
        num = int.Parse(Console.ReadLine());
        if (num < 20)
        {
            switch (num)
            {
                case 1: Console.WriteLine("one");
                    break;
                case 2: Console.WriteLine("two");
                    break;
                case 3: Console.WriteLine("three");
                    break;
                case 4: Console.WriteLine("four");
                    break;
                case 5: Console.WriteLine("five");
                    break;
                case 6: Console.WriteLine("six");
                    break;
                case 7: Console.WriteLine("seven");
                    break;
                case 8: Console.WriteLine("eight");
                    break;
                case 9: Console.WriteLine("nine");
                    break;
                case 10: Console.WriteLine("ten");
                    break;
                case 11: Console.WriteLine("eleven");
                    break;
                case 12: Console.WriteLine("twelve");
                    break;
                case 13: Console.WriteLine("thirteen");
                    break;
                case 14: Console.WriteLine("fourteen");
                    break;
                case 15: Console.WriteLine("fifteen");
                    break;
                case 16: Console.WriteLine("sixteen");
                    break;
                case 17: Console.WriteLine("seventeen");
                    break;
                case 18: Console.WriteLine("eighteen");
                    break;
                case 19: Console.WriteLine("ninteen");
                    break;
                case 0: Console.WriteLine("zero");
                    break;
            }
        }
        else if (num >= 20 && num < 100)
        {
            int ones, tens;
            ones = num % 10;
            num = num / 10;
            tens = num;
            switch (tens)
            {
                case 2: Console.Write("twenty ");
                    break;
                case 3: Console.Write("thirty ");
                    break;
                case 4: Console.Write("fourty ");
                    break;
                case 5: Console.Write("fifty ");
                    break;
                case 6: Console.Write("sixty ");
                    break;
                case 7: Console.Write("seventy ");
                    break;
                case 8: Console.Write("eighty");
                    break;
                case 9: Console.Write("ninety ");
                    break;
            }
            switch (ones)
            {
                case 1: Console.WriteLine("one");
                    break;
                case 2: Console.WriteLine("two");
                    break;
                case 3: Console.WriteLine("three");
                    break;
                case 4: Console.WriteLine("four");
                    break;
                case 5: Console.WriteLine("five");
                    break;
                case 6: Console.WriteLine("six");
                    break;
                case 7: Console.WriteLine("seven");
                    break;
                case 8: Console.WriteLine("eight");
                    break;
                case 9: Console.WriteLine("nine");
                    break;
            }
        }
        else if (num >= 100 && num < 1000)
        {
            int ones, tens, hundreds;
            ones = num % 10;
            num = num / 10;
            tens = num % 10;
            num = num / 10;
            hundreds = num;
            if (ones == 0 && tens == 0)
            {
                switch (hundreds)
                {
                    case 1: Console.WriteLine("one hundred ");
                        break;
                    case 2: Console.Write("two hundred ");
                        break;
                    case 3: Console.Write("three hundred ");
                        break;
                    case 4: Console.Write("four hundred ");
                        break;
                    case 5: Console.Write("five hundred ");
                        break;
                    case 6: Console.Write("six hundred ");
                        break;
                    case 7: Console.Write("seven hundred ");
                        break;
                    case 8: Console.Write("eight hundred ");
                        break;
                    case 9: Console.Write("nine hundred ");
                        break;
                }
            }
            else if ((tens * 10) + ones < 20)
            {
                ones = (tens * 10) + ones;
                tens = 0;
            }
            else if (tens != 0)
            {
                switch (hundreds)
                {
                    case 1: Console.Write("one hundred ");
                        break;
                    case 2: Console.Write("two hundred ");
                        break;
                    case 3: Console.Write("three hundred ");
                        break;
                    case 4: Console.Write("four hundred ");
                        break;
                    case 5: Console.Write("five hundred ");
                        break;
                    case 6: Console.Write("six hundred ");
                        break;
                    case 7: Console.Write("seven hundred ");
                        break;
                    case 8: Console.Write("eight hundred ");
                        break;
                    case 9: Console.Write("nine hundred ");
                        break;
                }
                switch (tens)
                {
                    case 2: Console.Write("and twenty ");
                        break;
                    case 3: Console.Write("and thirty ");
                        break;
                    case 4: Console.Write("and fourty ");
                        break;
                    case 5: Console.Write("and fifty ");
                        break;
                    case 6: Console.Write("and sixty ");
                        break;
                    case 7: Console.Write("and seventy ");
                        break;
                    case 8: Console.Write("and eighty");
                        break;
                    case 9: Console.Write("and ninety ");
                        break;
                    case 0: Console.Write("and ");
                        break;
                }
                switch (ones)
                {
                    case 1: Console.WriteLine("one");
                        break;
                    case 2: Console.WriteLine("two");
                        break;
                    case 3: Console.WriteLine("three");
                        break;
                    case 4: Console.WriteLine("four");
                        break;
                    case 5: Console.WriteLine("five");
                        break;
                    case 6: Console.WriteLine("six");
                        break;
                    case 7: Console.WriteLine("seven");
                        break;
                    case 8: Console.WriteLine("eight");
                        break;
                    case 9: Console.WriteLine("nine");
                        break;
                    case 10: Console.WriteLine("ten");
                        break;
                    case 11: Console.WriteLine("eleven");
                        break;
                    case 12: Console.WriteLine("twelve");
                        break;
                    case 13: Console.WriteLine("thirteen");
                        break;
                    case 14: Console.WriteLine("fourteen");
                        break;
                    case 15: Console.WriteLine("fifteen");
                        break;
                    case 16: Console.WriteLine("sixteen");
                        break;
                    case 17: Console.WriteLine("seventeen");
                        break;
                    case 18: Console.WriteLine("eighteen");
                        break;
                    case 19: Console.WriteLine("ninteen");
                        break;
                    case 0: Console.WriteLine("zero");
                        break;
                }
            }
        }
    }
}
