using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace MyCSharpSandbox
{
    class ThreadingExtended
    {
        //  Hier wird gezeigt, dass zwei unterschiedliche Threads 
        //  die die selbe Methode aufrufen, jeweils mit eigenen Kopien der
        //  Variablen arbeiten. Der Zählmechanismus der for-Schleifen wird
        //  daher nicht beeinträchtigt und das Ergebnis sind ===> 10 Fragezeichen.
        //  ACHTUNG:
        //  Die Ausgabe des zusätzlich gestarteten Threads erscheint wohlmöglich
        //  erst nach der Meldung "Press Enter to ..." aus Main().
        //  Abhilfe schafft "Join" (siehe ThreadingExtendedJoin.cs)

        public static void Start()
        {
            Console.WriteLine("MSG FROM: "+ (MethodBase.GetCurrentMethod().DeclaringType));

            new Thread(Go).Start();      // Call Go() on a new thread
            Go();                         // Call Go() on the main thread

        }

        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
        }
    }
}


