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
            Intro("\nWelcome. Don't Panic!");

            HideBehindInterface.Start();
            EventsAndDelegates.Start();

            #region Unused Stuff
            // AnotherIComparableExercise.Start();
            // IComparableTest.Start();
            // BaseConstructorTest.Start();
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

// Guter Tip am Rande:
//  In Visual Studio    [CTRL] + [J] = Intellisense Popup
//                      [CTRL] + [Space] = Intellisense Auto-Complete
//                      ( [CTRL] + [K] ) + ( [CTRL] + [C] ) = Zeile als Kommentar
//                      ( [CTRL] + [K] ) + ( [CTRL] + [U] ) = Kommentar-Zeichen entfernen