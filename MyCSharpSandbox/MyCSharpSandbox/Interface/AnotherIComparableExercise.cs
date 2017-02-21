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
            Spaceship GenericShip = new Spaceship();
            Spaceship Nostromo = new Spaceship("Nostromo", 15000, 6000000);
            Spaceship Betty = new Spaceship("Betty", 2000, 42000);
            Spaceship MilMal = new Spaceship("M. Mallard", 3000, 20000000);


            List<Spaceship> myFleet = new List<Spaceship> { GenericShip, Nostromo, MilMal, Betty };

            Console.WriteLine("\nComparing by name ...");
            Spaceship.compareBy = 0;
            sortFleet(myFleet);

            Console.WriteLine("\nComparing by weight ...");
            Spaceship.compareBy = 1;
            sortFleet(myFleet);

            Console.WriteLine("\nComparing by price ...");
            Spaceship.compareBy = 2;
            sortFleet(myFleet);
        }

        public static void sortFleet(List<Spaceship> tempList)
        {
            tempList.Sort();
            foreach (Spaceship x in tempList)
            {
                Console.WriteLine(x.ToString());
            }
        }

        public class Spaceship : IComparable<Spaceship>
        {
            public static int compareBy { get; set; }       // 0 = by name, 1 = by weight, 2 = by price
            public string name { get; private set; }
            public int weight { get; private set; }
            public int price { get; private set; }

            void initSpaceship(string newName, int newWeight, int newPrice)
            {
                compareBy = 0;
                weight = newWeight;
                price = newPrice;
                name = newName;
            }

            public int CompareTo(Spaceship rightSpaceship)
            {
                Spaceship leftSpaceship = this;

                if (compareBy == 0) // Compare by name
                {
                    return string.Compare(leftSpaceship.name, rightSpaceship.name);
                }
                else
                if (compareBy == 1) // Compare by weight
                {
                    if (leftSpaceship.weight == rightSpaceship.weight) { return 0; }
                    else
                    if (leftSpaceship.weight < rightSpaceship.weight) { return -1; }
                    else
                    if (leftSpaceship.weight > rightSpaceship.weight) { return 1; }
                }
                else if (compareBy == 2)    // Compare by price
                {
                    if (leftSpaceship.price == rightSpaceship.price) { return 0; }
                    else
                    if (leftSpaceship.price < rightSpaceship.price) { return -1; }
                    else
                    if (leftSpaceship.price > rightSpaceship.price) { return 1; }
                }
                return -1;
            }

            public override string ToString()   // ToString Override 
            {
                string fullSpecs = string.Format("Spaceship: {0} \t\tWeight: {1} tons \t\tPrice: ${2}", name, weight, price);
                return fullSpecs;
            }                                       

            public Spaceship()  // Base Constructor
            {
                initSpaceship("Unnamed", 10000, 1000000);
            }                                                   

            public Spaceship(string newName, int newWeight, int newPrice)   // Overloaded Constructor 
            {
                this.initSpaceship(newName, newWeight, newPrice);
            }       
        }
    }
}
