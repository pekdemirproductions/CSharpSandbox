using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class AnotherIComparableExercise
    {
        public static void Start()
        {
            Spaceship Nostromo = new Spaceship();
        }

        public class Spaceship
        {
            public int weight { get; private set; }
            public int price { get; private set; }

            void initSpaceship(int newWeight, int newPrice)
            {
                weight = newWeight;
                price = newPrice;
            }

            public Spaceship()
            {
                initSpaceship(10000, 1000000);
            }

            public Spaceship(int newWeight)
            {
                
            }
        }

    }
}
