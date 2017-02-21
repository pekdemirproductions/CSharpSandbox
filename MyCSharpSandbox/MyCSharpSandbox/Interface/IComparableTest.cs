using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class IComparableTest
    {
		public static void Start()
        {
            Lamp BasicCeiling = new Lamp("Basic Ceiling", 700);
            Lamp FloodLight = new Lamp("Floodlight", 5000);
            Lamp DeskSpot = new Lamp("Desktop Spotlight", 300);
            Lamp KeyChainLight = new Lamp("LED Keychain Light", 5);
            Lamp Flashlight = new Lamp("Small Flashlight", 100);


            List<Lamp> myLampList = new List<Lamp> { BasicCeiling, FloodLight, DeskSpot };
            myLampList.Add(KeyChainLight);
            myLampList.Add(Flashlight);

            List<Lamp> sortedLampList = new List<Lamp>(myLampList);
            sortedLampList.Sort();

            DisplayList(myLampList);
            DisplayList(sortedLampList);

        }

		public static void DisplayList(List<Lamp> tempList)
        {
            int counter = 0;
            foreach (Lamp tempLamp in tempList)
            {
                Console.WriteLine("Lamp {0}: Model[{1}], Lumen[{2}]", ++counter, tempLamp.model, tempLamp.lumen);
            }
        }

		public class Lamp : IComparable<Lamp>
        {
			public Lamp(string constrModel, int constrLumen)
            {
                Console.WriteLine("New Lamp '{0}' with {1} Lumen created.", constrModel, constrLumen);
                model = constrModel;
                lumen = constrLumen;
            }

            public string model { get; private set; }
            public int lumen { get; private set; }

			public int CompareTo(Lamp rightLamp)
            {
                Lamp leftLamp = this;

                if (leftLamp.lumen > rightLamp.lumen) { return -1; }
                else if (leftLamp.lumen < rightLamp.lumen) { return 1; }
                else
                {
                    return 0;
                }

            }
        }
    }
}
