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

            Intro("Welcome. Don't Panic!");

            UseSubclassAs.Start();

            #region Unused Stuff
            // VirtualMemberTest.Start();
            // AbstractClassTest.Start();

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
