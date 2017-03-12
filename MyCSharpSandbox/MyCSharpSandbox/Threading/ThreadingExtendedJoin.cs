using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace MyCSharpSandbox
{
    class ThreadingExtendedJoin
    {
        //  Ähnliche Situation wie in ThreadingExtended.cs, diesmal mit
        //  Join-Kommando, damit auf den Worker-Thread gewartet wird,
        //  bevor zu Main zurückgekehrt wird.

        public static void Start()
        {
            Console.WriteLine("MSG FROM: " + (MethodBase.GetCurrentMethod().DeclaringType));

            // new Thread(Go).Start();      // Call Go() on a new thread <= Anonym, geht nicht?

            Thread workerThread = new Thread(Go);   // Der Thread hat jetzt einen Namen.
            workerThread.Start();                   // Start-Methode wird im neuen Thread aufgerufen.
            Go();                                   // Go() wird im Main-Thread aufgerufen.
            workerThread.Join();
        }

        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
        }
    }
}


