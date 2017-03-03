using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class VirtualMemberTest
    {
        public static void Start()
        {
            BaseCalculator bc = new BaseCalculator();
            Console.WriteLine(bc.calculate(6, 7));

            SpecialCalculator sc = new SpecialCalculator();
            Console.WriteLine(sc.calculate(6, 7));

            // Anzahl aller bisherigen Berechnungen ausgeben:
            Console.WriteLine(BaseCalculator.allCalculations);

            // Die nachfolgende Anweisung ist ungültig, da "Set" private ist
            // BaseCalculator.allCalculations++;

        }
        // An abstract function has to be overridden 
        // while a virtual function may be overridden

        // Only members in C# can be virtual. Classes can be abstract.

        public class BaseCalculator
        {
            public static int allCalculations { get; private set; }

            virtual public int calculate(int a, int b)
            {
                allCalculations++;
                return a + b;
            }
        }

        public class SpecialCalculator : BaseCalculator
        {
            public override int calculate(int a, int b)
            {
                a *= 100;
                b *= 100;

                return base.calculate(a, b);
            }
        }

    }
}
