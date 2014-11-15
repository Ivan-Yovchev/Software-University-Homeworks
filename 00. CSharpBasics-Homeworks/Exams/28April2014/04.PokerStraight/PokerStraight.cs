using System;

class PokerStraight
{
    static void Main(string[] args)
    {
        int weight = int.Parse(Console.ReadLine());

        char[] suits = new char[] { 'C', 'D', 'H', 'S' };

        int count = 0;

        for (int card = 0; card < 10; card++)
        {
            for (int suit1 = 0; suit1 < 4; suit1++)
            {
                for (int suit2 = 0; suit2 < 4; suit2++)
                {
                    for (int suit3 = 0; suit3 < 4; suit3++)
                    {
                        for (int suit4 = 0; suit4 < 4; suit4++)
                        {
                            for (int suit5 = 0; suit5 < 4; suit5++)
                            {
                                int tempWieghtCard = 0, tempSuitwieght = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    tempWieghtCard += (GetCardWieght(card + i)*((i+1)*10));
                                }

                                tempSuitwieght += GetSuitWeight(suits[suit1]) + GetSuitWeight(suits[suit2]) 
                                    + GetSuitWeight(suits[suit3]) + GetSuitWeight(suits[suit4]) + GetSuitWeight(suits[suit5]);

                                if((tempSuitwieght + tempWieghtCard) == weight)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(count);
    }

    private static int GetSuitWeight(char suit)
    {
        int result = 0;

        switch(suit)
        {
            case 'C': result = 1; break;
            case 'D': result = 2; break;
            case 'H': result = 3; break;
            case 'S': result = 4; break;
        }

        return result;
    }

    private static int GetCardWieght(int card)
    {
        int result = 0;

        switch(card)
        {
            case 0: result = 1; break;
            case 1: result = 2; break;
            case 2: result = 3; break;
            case 3: result = 4; break;
            case 4: result = 5; break;
            case 5: result = 6; break;
            case 6: result = 7; break;
            case 7: result = 8; break;
            case 8: result = 9; break;
            case 9: result = 10; break;
            case 10: result = 11; break;
            case 11: result = 12; break;
            case 12: result = 13; break;
            case 13: result = 14; break;
        }

        return result;
    }
}

