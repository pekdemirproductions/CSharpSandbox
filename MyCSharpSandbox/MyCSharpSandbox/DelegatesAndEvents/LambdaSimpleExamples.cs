using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class LambdaSimpleExamples
    {
        public delegate int del(int i);
        public delegate string stringDel(string x, string y);

        public static void Start()
        {
            del myLambda = x => x + 10;
            Console.WriteLine(myLambda(100));

            myLambda = x => x - 10;
            Console.WriteLine(myLambda(100));

            stringDel myStringLambda = (x, y) => string.Format(x + y);
            Console.WriteLine(myStringLambda("A", "B"));
        }
    }
}
