using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;             //   <==========  WICHTIG

namespace MyCSharpSandbox
{
    class ThreadBasics
    {
        public static string currentX = "X";
        public static string currentY = "Y";
        public static Thread t = new Thread(WriteY); // Erzeugt neuen Thread t mit 
                                                     // Funktion WriteY als Parameter
        public static void Start()
        {
            // Do it
            // t = new Thread(WriteY);
            t.Start();
            WriteX();
        }

        public static void WriteX()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(ThreadBasics.currentX);
                Console.Write(t.IsAlive);
            }
        }
        public static void WriteY()
        {
            for (int i=0; i < 1000; i++)
            {
                Console.Write(ThreadBasics.currentY);
            }
        }
    }
}
