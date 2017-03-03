using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cleaned up 2017-02-12

            Intro("\nWelcome. Don't Panic!");

            InterfaceHideBehind.Start();

            #region Unused Stuff
            // InterfaceTest.Start();
            // UseSubclassAs.Start();
            // AbstractClassTest.Start();
            // VirtualMemberTest.Start();
            #endregion

            Outro("Goodbye.");

        }

        public static void Intro(string message)
        {
            Console.WriteLine(message + "\n");
        }
        public static void Outro(string message)
        {
            Console.WriteLine(message + "\n");
            Console.WriteLine("(Press Enter to terminate program.)");
            Console.ReadLine();
        }
    }
}
