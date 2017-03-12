using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class _Anonymous_Method_Final
    {
        delegate void numberChanger(int n);     // Irgendeinen delegate-Typ definieren

        public static void Start()
        {
            // Neue Delegate-Instanz mit anonymer Funktion/Methode erzeugen:
            // ================================================================
            numberChanger currentNumberChanger = delegate (int x)   
            {
                Console.WriteLine("Number Changer Method 1: " + x);
            };


            // Den Delegaten aufrufen ("invoke") 
            // ================================================================
            // Wir verwenden hier die verkürzte Schreibweise für der Aufruf.
            // Das vollständige Kommando lautet:
            // currentNumberChanger.Invoke(666);

            currentNumberChanger(666);


            // Und jetzt dem Delegate eine neue, anonyme Funktion zuweisen ...
            // ================================================================

            currentNumberChanger = delegate (int x)
            {
                Console.WriteLine("Number Changer Method 2: " + (x * 2));
            };

            currentNumberChanger(21);
        }
    }
}
