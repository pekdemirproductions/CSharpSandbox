using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;


namespace MyCSharpSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro("Welcome. Don't Panic!");

            ThreadingExtendedJoin.Start();

            #region Unused Stuff

            // *** Threading & Asynchronous Programming ***
            // ThreadingExtended.Start();
            // ThreadBasics.Start();

            // TEST AUF DELL-XEON-2
            // TEST AUF ASPIRE SWITCH

            // *** Delegates & Events ***
            // FinalDelegate.Start();
            // LambdaSimpleExamples.Start();
            // DelegateV5.Start();
            // EventHandlerV5.Start();
            // EventHandlerV4.Start();
            // EventHandlerOnceMore.Start();
            // EventHandlerExercise.Start();
            // SimpleDelegate.Start();
            // YetAnotherDelegate.Start();
            // Delegate_Revisited.Start();
            // EventsAndDelegates.Start();

            // *** Interfaces ***
            // HideBehindInterface.Start();
            // AnotherIComparableExercise.Start();
            // IComparableTest.Start();
            // InterfaceTest.Start();

            // *** Classes and Constructors
            // BaseConstructorTest.Start();
            // UseSubclassAs.Start();
            // AbstractClassTest.Start();
            // VirtualMemberTest.Start();

            // *** Useful Stuff ***
            // OverloadingOperators.Start();
            // RandomTimeBased.Start();
            // AufrufendeKlasseAnzeigen.Start();
            #endregion

            Outro("Goodbye. You are now leaving this awesome application ...");
        }

        static void Intro(string message)
        {
            string myOrigin = MethodBase.GetCurrentMethod().DeclaringType.ToString();
            int numberOfChars = message.Length;
            Console.WriteLine($"MSG FROM: {myOrigin}");
            LineFitted(message.Length);
            Console.WriteLine(message);
            LineFitted(message.Length);
            Console.Write("\n");
        }

        static void Outro(string message)
        {
            int numberOfChars = message.Length;

            Console.WriteLine("\n");
            LineFitted(message.Length);
            Console.WriteLine(message);
            LineFitted(message.Length);

            Console.ReadLine();
        }

        static void LineFitted(int curLength)
        {
            for (int i = 0; i < curLength; i++) { Console.Write("-"); }
            Console.Write("\n");
        }
    }
}

// Guter Tip am Rande:
//  In Visual Studio    [CTRL]+[J]                  = Intellisense Popup
//                      [CTRL]+[Space]              = Intellisense Auto-Complete
//                      [CTRL]+[K] => [CTRL]+[C]    = Zeile als Kommentar
//                      [CTRL]+[K] => [CTRL]+[U]    = Kommentar-Zeichen entfernen