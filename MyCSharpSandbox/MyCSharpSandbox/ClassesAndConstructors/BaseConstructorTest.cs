using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class BaseConstructorTest
    {
        public static void Start()
        {
            Computer T3500 = new Computer
            {
                brand = "Dell",
                model = "Precision T3500",
                processor = "Intel Xeon W5670",
                gigabytesOfRAM = 12
            };

            Workstation T7500 = T3500.CloneToNewWorkstation();

            string info = T3500.ToString();
            Console.WriteLine(info);

            T7500.gpu = "NVIDIA Quadro K6000";
            T7500.inputDevices = "3D Scanner, 2D Scanner, Wacom Tablet";
        }

        class Computer : ICloneable
        {
            public string brand;
            public string model;
            public string processor;
            public int gigabytesOfRAM;

            public override string ToString()
            {
                string fullDescription = string.Format("Brand: {0} / Model: {1} / CPU: {2} / RAM: {3}",
                    brand, model, processor, gigabytesOfRAM);
                return fullDescription;
            }

            public object Clone()
            {
                return new Computer
                {
                    brand = this.brand,
                    model = this.model,
                    processor = this.processor,
                    gigabytesOfRAM = this.gigabytesOfRAM

                };
            }

            // Overloading Clone to accept Workstation Class Objects
            public Workstation CloneToNewWorkstation()
            {
                return new Workstation
                {
                    brand = this.brand,
                    model = this.model,
                    processor = this.processor,
                    gigabytesOfRAM = this.gigabytesOfRAM
                };
            }

        }

        class Workstation : Computer, INetwork
        {
            public string gpu;
            public string inputDevices;
            public void ethernet()
            {
                Console.WriteLine("Connecting to virtual Ethernet ...");
            }
            public void wifi()
            {
                Console.WriteLine("Connecting to virtual Wi-Fi ...");
            }
        }

        public interface INetwork
        {
            void ethernet();
            void wifi();
        }

    }
}
