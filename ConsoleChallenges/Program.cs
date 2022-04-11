using System;
using System.Collections.Generic;

namespace ConsoleChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fb = new FizzBuzz();
            //fb.FirstTry(25);
            //fb.SecondTry(25);
            //fb.ThirdTry(25);
            //fb.FourthTry(25);
            //WordSearch.Go();
            //Qwerty.Go("woordy");
            var result = getHeaviestPackage(new List<int> { 4, 30, 15, 5, 9 });
        }

        /// <summary>
        /// ```mermaid
        /// graph TD
        ///     A[Christmas] -->|Get money| B(Go shopping)
        ///     B --> C{Let me think}
        ///     C -->|One| D[Laptop]
        ///     C -->|Two| E[iPhone]
        ///     C -->|Three| F[fa:fa - car Car]
        /// ```
        /// </summary>
        /// <param name="packageWeights"></param>
        /// <returns></returns>
        static long getHeaviestPackage(List<int> packageWeights)
        {
            var compare = 0;
            while (packageWeights.Count != compare)
            {
                compare = packageWeights.Count;
                for (int instance = 0; instance < packageWeights.Count; instance++)
                {
                    if (instance + 1 > packageWeights.Count - 1) break;
                    if (packageWeights[instance] < packageWeights[instance + 1])
                    {
                        packageWeights[instance] = packageWeights[instance] + packageWeights[instance + 1];
                        packageWeights.RemoveAt(instance + 1);
                    }
                }
            }

            var largest = 0;
            foreach (var package in packageWeights)
            {
                if (package >= largest) largest = package;
            }
            return largest;
        }
    }
}
