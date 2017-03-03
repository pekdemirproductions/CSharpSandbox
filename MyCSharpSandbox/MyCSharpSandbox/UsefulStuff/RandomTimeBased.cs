using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    public class RandomTimeBased
    {
        public static void Start()
        {

            Console.WriteLine("Here are some random numbers based on System.DateTime.Now.Millisecond:");

            for (int x = 1; x <= 10; x++)
            {
                Console.WriteLine("Number {0}: {1}", x, GetRandomNumber(1,101));
            }

        }

        // Aufruf mit 2 Parametern (min/max)
        public static int GetRandomNumber(int min, int max)
        {
            Thread.Sleep(1);
            int timeBasedSeed = System.DateTime.Now.Millisecond;
            Random rnd = new Random(timeBasedSeed);   // Seed based on System Time
            int newRandom = rnd.Next(min, max);
            return newRandom;
        }

        // Standard-Aufruf ohne Parameter (nimmt Zufallszahlen zwischen 0 und 101)
        public static int GetRandomNumber()
        {
            int newRandom = GetRandomNumber(0, 101);
            return newRandom;
        }


    }
}
