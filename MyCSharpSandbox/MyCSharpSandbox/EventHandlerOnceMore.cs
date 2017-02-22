using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    class EventHandlerOnceMore
    {
        public class DroneEventArgs : EventArgs
        {
            public int travelTime;
        }

        public static void Start()
        {
            DroneControl DroneControlAlpha = new DroneControl();
            DroneTerminal DroneTerminalAlpha = new DroneTerminal("Drone Terminal Alpha");
            DroneTerminal DroneTerminalBeta = new DroneTerminal("Drone Terminal Beta");
            DroneTerminal DroneTerminalGamma = new DroneTerminal("Drone Terminal Gamma");

            DroneControlAlpha.TargetReached += DroneTerminalAlpha.OutputDroneMessage;
            DroneControlAlpha.TargetReached += DroneTerminalBeta.OutputDroneMessage;
            DroneControlAlpha.TargetReached += DroneTerminalGamma.OutputDroneMessage;

            DroneControlAlpha.MoveDrone("100;59;44");

        }

        public class DroneControl
        {
            public delegate string DroneControlDelegate(object o, DroneEventArgs args);
            public event DroneControlDelegate TargetReached;

            string currentGpsPosition;
            string targetGpsPosition;

            public void MoveDrone(string newGpsPosition)
            {
                Console.WriteLine("New GPS target position received ({0}).");
                Console.WriteLine("Moving to new position ...");
                int travelTime = RandomTimeBased.GetRandomNumber(1000, 3000);
                Thread.Sleep(travelTime);

                onDroneArrivedAtTarget(this, new DroneEventArgs() { travelTime = travelTime });
            }

            protected virtual string onDroneArrivedAtTarget(object o, DroneEventArgs args)
            {
                if (TargetReached != null)
                    TargetReached(this, args);
                return string.Format("LAST GPS POSITION: {0} / NEW GPS POSITION {1}",
                    currentGpsPosition, targetGpsPosition);
            }
        }

        public class DroneTerminal
        {
            public string name { get; private set; }

            public DroneTerminal(string newName) { name = newName; }       // Constructor
            public string OutputDroneMessage(object o, DroneEventArgs args)
            {
                Console.WriteLine(
                    "{0}: Drone has reached new position. Travel time: {1}", name, args.travelTime);
                return String.Format("LOG: Message received at " + DateTime.Now.ToString());
            }
        }
    }
}
