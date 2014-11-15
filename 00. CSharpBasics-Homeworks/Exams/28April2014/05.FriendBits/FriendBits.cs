using System;

class FriendBits
{
    static void Main(string[] args)
    {
        uint num = uint.Parse(Console.ReadLine());

        if(num == 0)
        {
            Console.WriteLine(0);
            Console.WriteLine(0);
        }
        else
        {
            string number = Convert.ToString(num, 2);
            number += 'X';
            //Console.WriteLine(number);

            string friendBits = "", aloneBits = "";

            char compare = number[0];
            int count = 1;

            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] == compare)
                {
                    count++;
                }
                else if (number[i] != compare)
                {
                    if (count != 1)
                    {
                        friendBits += new string(compare, count);
                    }
                    else if (count == 1)
                    {
                        aloneBits += compare;
                    }

                    if (compare == '1')
                    {
                        compare = '0';
                        count = 1;
                    }
                    else if(compare == '0')
                    {
                        compare = '1';
                        count = 1;
                    }
                }

            }

            if(friendBits == "")
            {
                friendBits += '0';
            }
            else if(aloneBits == "")
            {
                aloneBits += '0';
            }

            //Console.WriteLine(friendBits);
            //Console.WriteLine(aloneBits);

            Console.WriteLine(Convert.ToUInt32(friendBits,2));
            Console.WriteLine(Convert.ToUInt32(aloneBits,2));
        }
    }
}

