using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox.Basics
{
    class Bedingungsoperatoren
    {
        public static void Start()
        {
            /* Im folgenden Beispiel liefert die Methode UseUmbrella
             * den Wert true zurück, wenn es regnet oder die Sonne scheint
             * (um uns vor dem Regen oder der Sonne zu schützen), solange es
             * nicht auch noch windig ist (da Regenschirme bei Wind nicht viel
             * helfen): */

            bool result = UseUmbrella(true, false, false);  // true
            Console.WriteLine(result);
        }

        public static bool UseUmbrella(bool rainy, bool sunny, bool windy)
        {
            return !windy && (rainy || sunny);
        }
    }
}
