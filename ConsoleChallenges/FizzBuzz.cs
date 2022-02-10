using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenges
{
    public class FizzBuzz
    {
        public void FirstTry(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var isFizz = false;
                var sb = new StringBuilder();
                sb.Append($"{i}: ");
                float fizz = (float)i / (float)3;
                float buzz = (float)i / (float)5;
                if (int.TryParse(fizz.ToString(), out int _))
                {
                    sb.Append("fizz");
                    isFizz = true;
                }
                if (int.TryParse(buzz.ToString(), out int _))
                {
                    if (isFizz) sb.Append(" ");
                    sb.Append("buzz");
                }
                Console.WriteLine(sb.ToString());
            }
        }

        public void SecondTry(int amount)
        {
            int fizzBuzzCount = 0, fizzCount = 0, buzzCount = 0;

            Parallel.For(0, amount, i =>
            {
                var isFizz = false;
                var sb = new StringBuilder();
                sb.Append($"{i}: ");
                if (i % 3 == 0)
                {
                    sb.Append("Fizz");
                    fizzCount++;
                    isFizz = true;
                }
                if (i % 5 == 0)
                {
                    if (isFizz) fizzBuzzCount++;
                    else buzzCount++;

                    sb.Append("Buzz");
                }
                Console.WriteLine(sb.ToString());
            });

            Console.WriteLine($"Fizz Total Count: {fizzCount}");
            Console.WriteLine($"Buzz Total Count: {buzzCount}");
            Console.WriteLine($"FizzBuzz Total Count: {fizzBuzzCount}");
        }

        public void ThirdTry(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var sb = new StringBuilder();
                sb.Append($"{i}: ");
                CheckNumber(i, 3, sb, "Fizz");
                CheckNumber(i, 5, sb, "Buzz");
                Console.WriteLine(sb.ToString());
            }
        }

        private void CheckNumber(int num, int div, StringBuilder sb, string wordIfDivisible)
        {
            if (num % div == 0)
            {
                sb.Append(wordIfDivisible);
            }
        }

        public void FourthTry(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var sb = new StringBuilder($"{i}: ");
                if (i % 3 == 0) sb.Append("Fizz");
                if (i % 5 == 0) sb.Append("Buzz");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
