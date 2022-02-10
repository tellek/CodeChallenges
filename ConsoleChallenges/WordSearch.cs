using ConsoleChallenges.Utilities;
using System;
using System.Collections.Generic;

namespace ConsoleChallenges
{
    public static class WordSearch
    {
        static int yMax;
        static int xMax;

        public static void Go()
        {
            var grid = new string[3, 4]
            {
                { "a", "a", "q", "t" },
                { "x", "c", "w", "e" },
                { "r", "l", "e", "p" },
            };
            yMax = grid.GetLength(0);
            xMax = grid.GetLength(1);

            findWord(grid, "ace");

            ConsoleUtils.Print2DArray(grid);
        }

        static void findWord(string[,] grid, string word)
        {
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    
                    if ((string)grid.GetValue(y, x) == word[0].ToString())
                    {
                        foreach (direction dir in Enum.GetValues(typeof(direction)))
                        {
                            var result = GetNextLetters(word, y, x, dir, grid);
                            if (result.Count == word.Length)
                            {
                                PrintGrid(grid, result);
                                return;
                            }
                        }
                    }
                }
            }
        }

        static void PrintGrid(string[,] grid, List<(int y, int x)> letterCoordinates)
        {
            foreach (var loc in letterCoordinates)
            {
                grid.SetValue("*", loc.y, loc.x);
            }
        }

        static List<(int y, int x)> GetNextLetters(string word, int y, int x, direction dir, string[,] grid)
        {
            var set = new List<(int y, int x)> { (y, x) };
            for (int i = 1; i < word.Length; i++)
            {
                var next = word[i].ToString();

                switch (dir)
                {
                    case direction.up:
                        y--;
                        break;
                    case direction.upright:
                        y--;
                        x++;
                        break;
                    case direction.right:
                        x++;
                        break;
                    case direction.downright:
                        y++;
                        x++;
                        break;
                    case direction.down:
                        y++;
                        break;
                    case direction.downleft:
                        y++;
                        x--;
                        break;
                    case direction.left:
                        x--;
                        break;
                    case direction.upleft:
                        y--;
                        x--;
                        break;
                }
                if (!WithinBounds(y, x)) return set;
                if ((string)grid.GetValue(y, x) == next) set.Add((y, x));
                else return set;
            }
            return set;
        }

        static bool WithinBounds(int y, int x)
        {
            if (x < 0 || x > (xMax - 1)) return false;
            if (y < 0 || y > (yMax - 1)) return false;
            return true;
        }

        enum direction
        {
            up,
            upright,
            right,
            downright,
            down,
            downleft,
            left,
            upleft
        }
    }
}
