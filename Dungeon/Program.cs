using D_and_D_demo.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();

            Hero hero = new Hero();
            hero.CoordinateX = 4;
            hero.CoordinateY = 4;
            bool flag = true;
            string[,] map = new string[50, 50];
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    map[i, j] = " ";
                }
            }
            CreateRoom(3, 3, 5, 9, map);
            CreateRoom(2, 8, 7, 10, map);
            CreateRoom(5, 14, 7, 12, map);
            pro.CreateHero(hero.CoordinateX, hero.CoordinateY, 0, 0, map, hero.KeyAvailability);
            CreateDoor(5, 8, map);
            CreateMonster(5, 5, map);
            ShowMap(map);

            while (flag)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Backspace:
                        flag = false;
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        if (pro.CreateHero(hero.CoordinateX, hero.CoordinateY - 1, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability))
                        {
                            hero.CoordinateY -= 1;
                        }
                        ShowMap(map);
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        if (pro.CreateHero(hero.CoordinateX, hero.CoordinateY + 1, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability))
                        {
                            hero.CoordinateY += 1;
                        }
                        ShowMap(map);
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        if (pro.CreateHero(hero.CoordinateX + 1, hero.CoordinateY, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability))
                        {
                            hero.CoordinateX += 1;
                        }
                        ShowMap(map);
                        break;
                    case ConsoleKey.W:
                        Console.Clear();
                        if (pro.CreateHero(hero.CoordinateX - 1, hero.CoordinateY, hero.CoordinateX, hero.CoordinateY, map,hero.KeyAvailability))
                        {
                            hero.CoordinateX -= 1;
                        }
                        ShowMap(map);
                        break;
                    default:
                        break;
                }

            }

            Console.ReadLine();
        }
        public string WallDoorMonsterCheck(int x, int y, string[,] map, bool key)
        {
            if (map[x, y] == "0")
            {
                return "wall";
            }
            else if(map[x,y] =="D")
            {
                return "door";
            }
            else if(map[x,y] == "M")
            {
                FightClub club = new FightClub();
                club.RandomFight();
                //club.ChoosenCreturesFight();
                key = true;                
                Console.WriteLine($"Now you have a key!");
                Console.ReadLine();
               
                return " ";
            }
            else
            {
                return " ";
            }


        }
        public static void CreateRoom(int baseX, int baseY, int x, int y, string[,] map)
        {
            for (int i = baseX; i < baseX + x; i++)
            {
                for (int j = baseY; j < baseY + y; j++)
                {
                    if (i == baseX || i == (baseX + x) - 1 || j == baseY || j == (baseY + y) - 1)
                    {
                        map[i, j] = "0";
                    }
                    else
                    {
                        map[i, j] = ".";
                    }
                }
            }
        }
        public static void CreateDoor(int x, int y, string[,] map)
        {
            map[x, y] = "D";
        }
        public static void CreateMonster(int x, int y, string[,] map)
        {
            map[x, y] = "M";
        }
        public bool CreateHero(int x, int y, int baseX, int baseY, string[,] map, bool key)
        {
            if (WallDoorMonsterCheck(x, y, map, key) == "wall")
            {
                return false;
            }
            else if (WallDoorMonsterCheck(x, y, map, key) == "door")
            {
                if (key == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                map[x, y] = "H";
                MoveClear(baseX, baseY, map);
                return true;
            }
        }
        public void MoveClear(int x, int y, string[,] map)
        {
            map[x, y] = ".";
        }
        public static void ShowMap(string[,] map)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (j < 25)
                    {
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.WriteLine(map[i, j]);
                    }

                }
            }
        }
    }
}
