using System;
// *** NEUES FEATURE ***
// Das hier geht scheinbar erst seit C# Version 6 (Quelle: Stackoverflow)
using static MyCSharpSandbox.RandomTimeBased;

namespace MyCSharpSandbox.DelegatesAndEvents
{
    class UsingStaticMynamespaceMyclass
    {
        public static void Start()
        {
            GetRandomNumber(1, 1000);   // Kurzform dank "using static ..."

            // RandomTimeBased.GetRandomNumber(1, 1000); // Lange Variante ...
        }

        
    }
}
