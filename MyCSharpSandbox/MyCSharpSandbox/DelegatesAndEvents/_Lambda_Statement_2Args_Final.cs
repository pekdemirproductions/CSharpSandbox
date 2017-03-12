using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class _Lambda_Statement_2Args_Final
    {
        // Delegate-Typ mit 2 Argumenten definieren ...
        // ================================================================
        delegate int myDel(Student x, string y);


        public static void Start()
        {
            // Neuen Studenten erzeugen zum rumspielen ...
            // ================================================================
            Student Anton = new Student() { name = "Anton", id = 1001 };


            // Zwei unterschiedliche Lambda-Statements erzeugen ...
            // ================================================================
            myDel myGetNameLengthLambda = (s, myString) =>                  // Lambda 1
            { return s.name.Length + myString.Length; };

            myDel myGetIdLambda = (s, myString) =>                          // Lambda 2
            { return s.id + myString.Length; };


            // Lambda-Delegaten ausführen inklusive Parameter-Übergabe ...
            // ================================================================
            int result = myGetNameLengthLambda(Anton, "Zickezackezickezackehoihoihoi");
            int result2 = myGetIdLambda(Anton, "Zickezackezickezackehoihoihoi");

            Console.WriteLine("Student name length: " + result);
            Console.WriteLine("Student id: " + result2);
        }

        public class Student
        {
            public int id { get; set; }
            public string name { get; set; }

        }
    }
}

