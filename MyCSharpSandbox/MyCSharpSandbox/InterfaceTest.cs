using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class InterfaceTest
    {
        public static void Start()
        {
            Creature rabbit = new Creature();
            Insect bee = new Insect();

            int stingXTimes = 6;

            for (int i = 0; i < stingXTimes; i++)
            {
                bee.Sting(rabbit);
            }
        }

        interface IStinger
        {
            int stingDamage { get; }
            void Sting(Creature victim);
        }

        public class Creature
        {
            public int health { get; private set; } = 100;
            public string creatureName = "Unknown Creature";
            public void healthAdd(int newAddHealth)
            {
                health = health + newAddHealth;
                if (health > 100) { health = 100; }
            }
            public void healthSubtract(int newSubtractHealth)
            {
                if ((health - newSubtractHealth) < 0)
                {
                    health = 0;
                    Console.WriteLine("The creature called '{0}' died!", creatureName);
                }
                else
                {
                    health = health - newSubtractHealth;
                    Console.WriteLine("STING!!! Health points lost: {0}. (Current Health: {1})",
                        newSubtractHealth, health);
                }


            }
        }

        public class Insect : Creature, IStinger
        {
            public int stingDamage { get; private set; } = 20;
            public void Sting(Creature victim)
            {
                victim.healthSubtract(stingDamage);
            }
        }
    }
}
