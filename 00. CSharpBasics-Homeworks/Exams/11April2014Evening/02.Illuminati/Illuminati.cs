using System;

class Illuminati
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        char[] letters = text.ToCharArray();

        int vowels = 0;
        int sum = 0;

        for (int i = 0; i < letters.Length; i++)
        {
            char temp = char.ToUpper(letters[i]);

            if (temp == 'A' || temp == 'E' || temp == 'I' || temp == 'O' || temp == 'U')
            {
                vowels++;
                sum += GetCharValue(temp);
            }
        }

        Console.WriteLine(vowels);
        Console.WriteLine(sum);
    }

    private static int GetCharValue(char p)
    {
        int result = 0;

        switch(p)
        {
            case 'A': result = 65; break;
            case 'E': result = 69; break;
            case 'I': result = 73; break;
            case 'O': result = 79; break;
            case 'U': result = 85; break;
        }

        return result;
    }
}

