using System;
class StudentCables
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int cableLength = 504;
        int cable = 0;
        int remove = 0;

        string[] measures = new string[2 * n];

        for (int i = 0; i < 2*n; i++)
        {
            string temp = Console.ReadLine();
            measures[i] = temp;
        }

        //get the full length of the cable and count how much must be removed 
        for (int i = 0; i < 2*n; i+=2)
        {
            int pieceOfCable = int.Parse(measures[i]);
            string measure = measures[i + 1];

            if(measure == "meters")
            {
                cable += pieceOfCable * 100;
                remove++;
            }
            else if(measure == "centimeters")
            {
                if(pieceOfCable < 20)
                {
                    continue;
                }
                else if(pieceOfCable >= 20)
                {
                    cable += pieceOfCable;
                    remove++;
                }
            }
        }

        //cut of a part from the cable
        cable = cable - ((remove - 1)* 3);

        //calculate how many cables can me made from the one we just created
        if(cable < 504)
        {
            Console.WriteLine(0);
            Console.WriteLine(cable);
        }
        else
        {
            for (int i = 1; i <= cable / cableLength; i++)
            {
                int numberOfcables = cable - (i * cableLength);
                if (numberOfcables < cableLength)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(numberOfcables);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

