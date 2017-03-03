using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    class YetAnotherDelegate
    {
        public delegate void DroidControlDelegate(Droid input, String args);

        public static void Start()
        {
            Droid T800 = new Droid() { name = "T800", id = 4242 };

            DroidControlDelegate currentDelegateAgent = new DroidControlDelegate(DroidMoverV3);


            T800.currentVector = "0;0;0";
            T800.targetVector = "123;15;456";
            
            T800.ExtensionPoint(currentDelegateAgent);

            Console.WriteLine();

            // string response = T800.GoToVector();
            Console.WriteLine("Bla End");

        }

        public static void DroidMoverV3(Droid controlledDroid, String incomingArgs)
        {
            Console.WriteLine("Droid {0} is now moving from vector [{1}] to vector [{2}], Sir!", 
                controlledDroid.name, incomingArgs, controlledDroid.targetVector);
            Random rnd = new Random(42);
            int moveDuration = rnd.Next(1000, 3000);
            Thread.Sleep(moveDuration);
            Console.WriteLine("Arrived at vector {0} in {1} miliseconds, Sir!",
                controlledDroid.targetVector, moveDuration);
        }


        public class Droid
        {
            public string name;
            public int id;
            public string currentVector;
            public string targetVector;
            public void ExtensionPoint(DroidControlDelegate incomingDelegate)
            {
                incomingDelegate.Invoke(this, currentVector);  // currentVector hier ist Quatsch!?
                // Syntax oben ist identisch mit:
                // incomingDelegate(this, currentVector);

            }
        }
    }
}
