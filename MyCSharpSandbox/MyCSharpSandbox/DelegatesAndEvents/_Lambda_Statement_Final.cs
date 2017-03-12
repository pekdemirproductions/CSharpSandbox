using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    public class _Lambda_Statement_Final
    {
        delegate int myDel(Student x);

        public static void Start()
        {
            Student Anton = new Student() { name = "Anton", id = 1001 };

            myDel myGetNameLengthLambda = s => { return s.name.Length; };   // Lambda 1
            myDel myGetIdLambda = s => { return s.id; };                    // Lambda 2

            int result = myGetNameLengthLambda(Anton);
            int result2 = myGetIdLambda(Anton);

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

