using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenges
{
    public static class Qwerty
    {
        static int yMax;
        static int xMax;

        public static void Go(string word)
        {
            var grid = new char[3, 10]
            {
                { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' },
                { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';' },
                { 'z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.', '/' },
            };
            yMax = grid.GetLength(0);
            xMax = grid.GetLength(1);
            var coordinates = new Dictionary<char, (int y, int x)>();

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    coordinates.Add(grid[y, x], (y, x));
                }
            }

            var sb = new StringBuilder();

            (int y, int x) last = (0, 0);
            foreach (var letter in word)
            {
                var vertical = coordinates[letter].y;
                var horizontal = coordinates[letter].x;

                sb.AppendLine(FindNextSteps(last, (vertical, horizontal)));
                last = (vertical, horizontal);
            }

            Console.WriteLine(sb.ToString());
        }

        static string FindNextSteps((int y, int x) last, (int y, int x) next)
        {
            if (next.Equals(last)) return "select";
            var sb = new StringBuilder();

            if (last.y != next.y)
            {
                if (last.y > next.y)
                {
                    sb.Append(ClickityClackity(last.y - next.y, "up"));
                }
                else
                {
                    sb.Append(ClickityClackity(next.y - last.y, "down"));
                }
            }
            if (last.x != next.x)
            {
                if (last.x > next.x)
                {
                    sb.Append(ClickityClackity(last.x - next.x, "left"));
                }
                else
                {
                    sb.Append(ClickityClackity(next.x - last.x, "right"));
                }
            }

            sb.Append("select");
            return sb.ToString();
        }

        static string ClickityClackity(int amount, string direction)
        {
            var result = String.Empty;
            for (int i = 0; i < amount; i++)
            {
                result += $"{direction},";
            }
            return result;
        }
    }
}
