using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class DasKomischeFragezeichen
    {
        public static void Start()
        {
            int? x;     // Kann eine Ganzzahl (-/0/+) ODER == null darstellen!
            x = null;   // Erlaubt!

            int y;      // Normales Integer ...
            y = 100;
            // y = null;   // Fehler / nicht erlaubt

            string myString;    // Ein String darf auch ohne "?" den Wert null enthalten
            myString = null;

            Console.WriteLine(x + y + myString);
        }
    }
}
