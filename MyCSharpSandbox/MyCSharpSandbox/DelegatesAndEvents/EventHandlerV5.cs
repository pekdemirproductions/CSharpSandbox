using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static MyCSharpSandbox.RandomTimeBased;

namespace MyCSharpSandbox
{
    class EventHandlerV5
    {
        public static void Start()
        {
            Satellite X1 = new Satellite("X1");
            Satellite X2 = new Satellite("X2");

            ComStation MoonBase1 = new ComStation("Moon Base 1");

            X1.NewPositionReached += MoonBase1.OutputSatelliteMessages;
            X2.NewPositionReached += MoonBase1.OutputSatelliteMessages;

            X1.MoveToNewPosition("100,50,20");
            X2.MoveToNewPosition("494,43,222");
        }

        public class SatelliteEventArgs : EventArgs
        {
            public string satelliteName;
            public string coordinates;
            public int travelTime;
            public string fullMessage;
        }

        // 

        public class Satellite
        {
            public string name { get; private set; }
            public string currentPosition { get; private set; }

            public Satellite(string newName) { name = newName; }
            public delegate string SatelliteEventHandler(object o, SatelliteEventArgs args);

            // Define the Event:
            public event SatelliteEventHandler NewPositionReached;

            public void MoveToNewPosition(string newPosition)
            {
                Console.WriteLine("Satellite {0} (currently at Position {1}) is moving to new position {2}",
                    this.name, currentPosition, newPosition);
                int currentTravelTime = GetRandomNumber(1000, 3000);
                Thread.Sleep(currentTravelTime);

                // Raise the Event:
                onNewPositionReached(this, new SatelliteEventArgs { satelliteName = this.name, coordinates = this.currentPosition, travelTime = currentTravelTime });
            }

            protected virtual string onNewPositionReached(object o, SatelliteEventArgs args)                                               // Extension Point
            {
                string currentFullMessage;
                if (NewPositionReached != null)
                {
                    currentFullMessage = string.Format(
                        "Satellite: {0} (old Position: {1}) successfully moved to Position: {2}. Travel Time was: {3}",
                        args.satelliteName, this.currentPosition, args.coordinates, args.travelTime);
                    currentPosition = args.coordinates;
                    args.fullMessage = currentFullMessage;
                    NewPositionReached(o, args);
                }
                else
                    currentFullMessage = "No message. Is this line Bullshit? I don't know.";

                return currentFullMessage;
            }
        }

        public class ComStation
        {
            public string name { get; set; }
            public ComStation(string newName) { name = newName; }

            public string OutputSatelliteMessages(object o, SatelliteEventArgs args)
            {
                Console.WriteLine("MESSAGE FROM {0}: {1}", name, args.fullMessage);
                return args.fullMessage;
            }
        }
    }
}
