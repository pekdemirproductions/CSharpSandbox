using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class SimpleDelegate
    {
        public delegate void MyDelegate(string inputString);


        public static void Start()
        {
            // Kurzform für die Erstellung des Delegat-Objekts
            MyDelegate callSomeFunction = SomeFunction;

            // Lange Schreibweise (mit selber Wirkung) wäre:
            // MyDelegate callSomeFunction = new MyDelegate(SomeFunction);

            callSomeFunction("I am a String!");

        }

        public static void SomeFunction(string someString)
        {
            Console.WriteLine("I am the Alpha and the Omega. Here's your string: " + someString);
        }


    }
}
