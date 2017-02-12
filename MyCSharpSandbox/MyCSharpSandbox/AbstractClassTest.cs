using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class AbstractClassTest
    {
        public static void Start()
        {
            CellPhone SamsungS7 = new CellPhone("+491724960078", "Samsung S7", "Ring Ring");

            SamsungS7.outputSound();
            Console.WriteLine(SamsungS7.phoneNumber);
            
            // Folgendes Object kann nicht erzeugt werden, da die Klasse abstrakt ist:
            // ElectronicDevice someDevice = new ElectronicDevice();
        }

        abstract public class ElectronicDevice
        {
            public int voltage;
            public string name;
            public string sound;
            public void outputSound()
            {
                Console.WriteLine("{0} makes this sound: {1}.", name, sound);
            }
        }

        public class CellPhone : ElectronicDevice
        {
            public string phoneNumber;

            public CellPhone(string newPhoneNumber, string newName, string newSound)
            {
                this.phoneNumber = newPhoneNumber;
                name = newName;
                sound = newSound;
            }

        }
    }
}
