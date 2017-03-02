using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    public static class FinalDelegate
    {
        public delegate string myDel(int x, int y, int z);

        public static void Start()
        {
            myDel formatCoordinates = AusgabeMethode1;       // Setze den Delegaten auf Methode 1
            workhorse(formatCoordinates);
            formatCoordinates = AusgabeMethode2;             // Setze den Delegaten auf Methode 2
            workhorse(formatCoordinates);
        }

        // Workhorse-Method - WIRD NICHT GEÄNDERT
        public static void workhorse(myDel currentDelegate)
        {
            // Hier könnten jetzt irgendwie die Werte XYZ generiert werden ...
            currentDelegate.Invoke(3, 4, 5);
        }

        // Hipster-Method 1
        public static string AusgabeMethode1(int cX, int cY, int cZ)
        {
            string result = string.Format($"X = {cX} / Y = {cY} / Z = {cZ}");
            Console.WriteLine(result);
            return result;
        }

        // Hipster-Method 2
        public static string AusgabeMethode2(int cX, int cY, int cZ)
        {
            string result = string.Format($"[X = {cX}] [Y = {cY}] [Z = {cZ}]");
            Console.WriteLine(result);
            return result;
        }
    }
}
