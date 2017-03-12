using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class _Delegate_Simple_Final
    {
        // Simple Named Delegate
        delegate int doSomething(string a, string b);

        public static void Start()
        {
            // Simple Named Delegate Instance
            doSomething myDoSomething = GetLengthOfTwoStrings;              // Assignment 1
            int result = myDoSomething("Jucki", "Ducki");                   // Call 1
            Console.WriteLine("Length: " + result);

            // Now change the Delegate pointer to a different method (B)
            myDoSomething = GetProductOfLengths;                            // Assignment 2
            result = myDoSomething("OK", "Computer");                       // Call 2
            Console.WriteLine("Product: " + result);
        }

        // Method for simple named Delegate
        public static int GetLengthOfTwoStrings(string curA, string curB)   // Method A
        {
            return curA.Length + curB.Length;
        }

        public static int GetProductOfLengths(string curA, string curB)     // Method B
        {
            return curA.Length * curB.Length;
        }
    }
}
