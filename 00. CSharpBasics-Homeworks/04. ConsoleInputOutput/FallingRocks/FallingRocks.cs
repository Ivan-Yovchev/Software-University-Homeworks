using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FallingRocks
{
    struct Dwarf
    {
        public int x;
        public int y;
        public string c;
        public ConsoleColor color;
    }
    struct Rock
    {
        public int x;
        public int y;
        public string c;
        public ConsoleColor color;
    }

    static void PrintDwarfPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void PrintPositionRock(int x, int y, string c, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void PrintGameInfo(int x, int y, string str, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static char []RockShapes = {'^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };

    static void Main()
    {
        int gameAreaWidth = 42;
        int speed = 150;
        Console.BufferHeight = Console.WindowHeight = 40;
        Console.BufferWidth = Console.WindowWidth = 45;
        Dwarf dwarf = new Dwarf();
        dwarf.x = gameAreaWidth/2;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.c = "(0)";
        dwarf.color = ConsoleColor.White;
        Random randomGenerator = new Random();
        List<Rock> rocks = new List<Rock>();
        string rockSize = "";

        while (true)
        {
            int rockColor = randomGenerator.Next(0,6);
            int chance = randomGenerator.Next(0, 101);
            int PickRock = randomGenerator.Next(0, 12);
            int RockLenght = randomGenerator.Next(0, 4);

            Rock newRock = new Rock();
            switch(rockColor)
            {
                case 0: newRock.color = ConsoleColor.Blue; break;
                case 1: newRock.color = ConsoleColor.Green; break;
                case 2: newRock.color = ConsoleColor.Magenta; break;
                case 3: newRock.color = ConsoleColor.Red; break;
                case 4: newRock.color = ConsoleColor.Yellow; break;
                case 5: newRock.color = ConsoleColor.Cyan; break;
            }
            newRock.x = randomGenerator.Next(0, gameAreaWidth);
            newRock.y = 0;
            if (chance < 31)
            {
                rockSize = new string(RockShapes[PickRock], RockLenght);
            }
            else
            {
                rockSize = new string(RockShapes[PickRock], 1);
            }
            newRock.c = "" + rockSize;
            rocks.Add(newRock);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x >= 1)
                        dwarf.x--;
                }
                else if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x < gameAreaWidth - 1)
                        dwarf.x++;
                }
            }
            List<Rock> newList = new List<Rock>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldrock = rocks[i];
                Rock newrock = new Rock();
                newrock.x = oldrock.x;
                newrock.y = oldrock.y + 1;
                newrock.c = oldrock.c;
                newrock.color = oldrock.color;

                if (newrock.y == dwarf.y)
                {
                    for (int k = 0; k < newrock.c.Length; k++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (newrock.x + k == dwarf.x + j)
                            {
                                Console.Beep();
                                PrintGameInfo(13, 10, "GAME OVER !!!", ConsoleColor.Red);
                                PrintGameInfo(13, 12, "Press [Enter] to exit...", ConsoleColor.Red);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                    }

                }
               
                if (newrock.y < Console.WindowHeight)
                {
                    newList.Add(newrock);
                }
            }
            rocks = newList;
            Console.Clear();
            foreach (Rock rock in rocks)
            {
                PrintPositionRock(rock.x, rock.y, rock.c, rock.color);
            }

            PrintDwarfPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
            System.Threading.Thread.Sleep(speed);
        }
    }
}
