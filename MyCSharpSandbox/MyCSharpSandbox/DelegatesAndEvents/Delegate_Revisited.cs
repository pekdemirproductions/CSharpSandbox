using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    class Delegate_Revisited
    {
        public delegate string SpaceshipDelegate(Spaceship input);
        SpaceshipDelegate myDel = new SpaceshipDelegate(GetSpaceshipInfoFull);

        public static void Start()
        {
            Spaceship Nostromo = new Spaceship();
            Nostromo.name = "Nostromo";
            Nostromo.weight = 12345;
            Nostromo.price = 567890;

            Console.WriteLine(Nostromo.ShipStatus(GetSpaceshipInfoFull)); 

            Console.WriteLine("Waiting ...");
            Thread.Sleep(1000);
            Console.WriteLine("Done!");
        }

        public static string GetSpaceshipInfoFull(Spaceship tempSpaceship)
        {
            string x = String.Format("{0} : {1} kg : ${2}",
                tempSpaceship.name, tempSpaceship.weight, tempSpaceship.price);
            return x;
        }

        public class Spaceship
        {
            public string name = "Generic Spaceship";
            public int weight = 1000;
            public int price = 5000000;

            public void TakeOff()
            {
                Console.WriteLine("Take-off in progress ...");
                Thread.Sleep(300);
            }

            public string ShipStatus(SpaceshipDelegate someShipInfoMethod)
            {
                return someShipInfoMethod(this);        // this = aktuelles Spaceship-Object,
                                                        // this wird hiermit an die in someShipInfoMethod
                                                        // verwiesene Methode übergeben. Das Ergebis
                                                        // ist dann ein String, den dann wiederum
                                                        // ShipStatus zurück gibt. Vorteil: Die Spaceship
                                                        // Klasse braucht nicht verändert werden und
                                                        // kann trotzdem erweitert werden.
            }
        }
    }
}
