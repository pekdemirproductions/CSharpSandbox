using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;        //      <====   Wichtig! Sonst geht's nicht ...


namespace MyCSharpSandbox
{
    class AufrufendeKlasseAnzeigen
    {
        // 
        public static void Start()
        {
            Console.WriteLine("Diese Meldung kommt aus der Klasse:");
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType);
            Console.WriteLine("\n\nAusgabe der aufrufenden Klasse erfolgt durch folgendes Kommando:");
            Console.WriteLine("Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType);");
            Console.WriteLine("\nWichtig: using System.Reflection; muss ebenfalls vorhanden sein!\n");
        }
    }
}
