using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MyCSharpSandbox
{
    class EventHandlerGroundhogDay
    {
        // Neue, abgeleitete EventArgs-Klasse
        public class BeeEventArgs : EventArgs { public string flowerCoords; }

        public static void Start()
        {
            Bee Maja = new Bee("Maya");
            Bee Willi = new Bee("Willi");

            Hive Garten = new Hive("Garten");

            Maja.FlowerFound += Garten.BroadcastNewFlower;
            Willi.FlowerFound += Garten.BroadcastNewFlower;

            Maja.SearchForFlower();
            Willi.SearchForFlower();

        }



        public class Bee
        {
            public string beeName;
            public Bee(string newName) { beeName = newName; }

            public delegate void BeeEventHandler(object o, BeeEventArgs BEA);
            public event BeeEventHandler FlowerFound;

            // Workhorse-Method
            public void SearchForFlower()
            {
                string CoordsXYZ = "1, 2, 3";
                Thread.Sleep(1000);
                BeeEventArgs BEA = new BeeEventArgs() { flowerCoords = CoordsXYZ } ;
                // Blume an Koordinaten XYZ gefunden. Meldung machen:
                onFlowerFound(this, BEA);
            }

            protected virtual void onFlowerFound(object o, BeeEventArgs BEA)
            {
                if (FlowerFound != null)
                {
                    FlowerFound(this, BEA);
                }
            }

        }

        public class Hive
        {
            public string hiveName;
            public Hive(string newName) { hiveName = newName; }

            public void BroadcastNewFlower (object o, BeeEventArgs BEA)
            {
                Bee tempBee = (Bee)o;
                Console.WriteLine("Bee {0} has found a flower at Coordinates {1}!",
                    tempBee.beeName, BEA.flowerCoords);
            }

        }

    }
}
