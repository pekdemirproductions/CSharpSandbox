using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    class DelegateV5
    {

        public delegate void MyDelegate(int i);
        
        public static void Start()
        {
            Car Audi = new Car() { name = "Audi A6" };

            MyDelegate myDel1 = new MyDelegate(Audi.StartCar);
            myDel1(420);

        }

        public class Car
        {
            public string name;

            public void StartCar(int i)
            {
                Console.WriteLine("Vroom "+i);
            }
        }


    }
}
