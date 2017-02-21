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
            // Let's create some Creatures
            Creature rabbit = new Creature("Rabbit");
            Creature mouse = new Creature();
            DangerousInsect bee = new DangerousInsect("Bee");

            // Now let the Bee sting the Rabbit a few times ...
            int stingXTimes = 6;

            for (int i = 0; i < stingXTimes; i++)
            { bee.Sting(rabbit); }

            // Now let's kill the mouse:
            for (int i = 0; i < stingXTimes; i++)
            { bee.Sting(mouse); }

            // As the job is done, let's move the bee to somewhere else ...
            bee.Move(10, 20);
            Console.WriteLine(bee.Position);

            // Now, due to radioactivity, the poison of our 
            // stinging insects will be multiplied (*2)

            RaiseStingingPower(2, bee);
            Console.WriteLine("Sting Damage is now: {0}", bee.stingDamage);

        }

        static void RaiseStingingPower(int raiseStingingPowerBy, IStinger tempIStinger)
        {
            // This won't work for some reason:
            // tempIStinger.stingDamage = tempIStinger.stingDamage * raiseStingingPowerBy;
            
            // But this does:
            DangerousInsect tempDangerousInsect = tempIStinger as DangerousInsect;
            if (tempDangerousInsect != null)
            {
                Console.WriteLine("Raising Sting damage by {0} for creature {1}", raiseStingingPowerBy, tempDangerousInsect.creatureName);
                tempDangerousInsect.stingDamage = tempDangerousInsect.stingDamage * raiseStingingPowerBy;
            }
        }


        // This is the interface for all stinging creatures and things
        interface IStinger
        {
            int stingDamage { get; }
            void Sting(Creature victim);
        }

        // We will also create an interface for movement
        interface IMoveable
        {
            int x { get; }
            int y { get; }
            void Move(int newX, int newY);
            string Position { get; }
        }


        public class Creature
        {
            public int health { get; private set; } = 100;
            public string creatureName { get; private set; }

            public Creature() : this("No Name")
            {
            }

            public Creature(string newName)
            {
                creatureName = newName;
            }

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

        // Now we will define a regular non-dangerous Insect.
        // (No stinging = no IStinger interface)

        public class Insect : Creature, IMoveable
        {
            // First, let's call the base class constructor:
            public Insect(string Name) : base(Name) { }

            // We MUST implement the following in order to fulfill the IMoveable interface requirements:
            public int x { get; private set; }
            public int y { get; private set; }

            // Here we define, how insects move:
            public void Move(int newX, int newY)
            {
                x = x + newX;
                y = y + newY;
            }

            public string Position
            {
                get
                {
                    return string.Format("Position of {0}: X = {1}, Y = {2}.", creatureName, x, y);
                }
            }

            // And let's also add some other useless shit, just to make it look more complete
            public int numberOfAntennas { get; private set; } = 2;

            string IMoveable.Position
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        public class DangerousInsect : Insect, IStinger
        {
            // We need to call the base constructor again from here:
            public DangerousInsect(string Name) : base(Name)
            {
                Console.WriteLine("WARNING! Dangerous Insect {0} with a Sting damage of {1} was born!", creatureName, stingDamage);
            }

            public int stingDamage { get; set; } = 20;
            public void Sting(Creature victim)
            {
                victim.healthSubtract(stingDamage);
            }
        }
    }
}
