using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static MyCSharpSandbox.RandomTimeBased;

namespace MyCSharpSandbox
{
    class EventHandlerV4
    {
        public static void Start()
        {
            // Do it
            Submarine Nautilus = new Submarine("Nautilus");
            Submarine U96 = new Submarine("U96");
            Submarine YellowSubmarine = new Submarine("Yellow Submarine");

            Harbor PearlHarbor = new Harbor("Pearl Harbor");

            Nautilus.NewDepthReached += PearlHarbor.DecodeMessagesFromSubmarines;
            U96.NewDepthReached += PearlHarbor.DecodeMessagesFromSubmarines;
            YellowSubmarine.NewDepthReached += PearlHarbor.DecodeMessagesFromSubmarines;

            Nautilus.DiveToDepth(150);
            U96.DiveToDepth(500);
            YellowSubmarine.DiveToDepth(42);
        }

        public class SubmarineEventArgs : EventArgs
        {
            public int timePassed;
            public string nameOfSubmarine;
        }

        public class Submarine
        {
            public Submarine(string newName) { name = newName; }

            public delegate string SubmarineEventHandler(object o, SubmarineEventArgs args);
            public event SubmarineEventHandler NewDepthReached;                             // Event

            public string name { get; private set; }
            public int depth { get; set; }

            public string DiveToDepth(int newDepth)
            {
                // Simulated Diving ...
                Console.WriteLine("{0} is now diving to new depth of: {1}", name, newDepth);
                depth = newDepth;
                int actualTimePassed = GetRandomNumber(1000, 10000);
                Thread.Sleep(actualTimePassed);
                onNewDepthReached(this, new SubmarineEventArgs() { timePassed = actualTimePassed, nameOfSubmarine = this.name });
                return string.Format("Diving completed at " + DateTime.Now.ToString());
            }

            protected virtual void onNewDepthReached(object o, SubmarineEventArgs args)     // Extension Point
            {
                if (NewDepthReached != null)
                    NewDepthReached(o, args);
            }
        }

        public class Harbor
        {
            public string name { get; private set; }
            public Harbor(string newName) { name = newName; }

            public string DecodeMessagesFromSubmarines(object o, SubmarineEventArgs args)
            {
                string returnMessage = string.Format(
                    "{0} INTERCOM MESSAGE: Submarine {1} reached new position in {2} Seconds.", 
                    this.name, args.nameOfSubmarine, args.timePassed);
                Console.WriteLine(returnMessage);
                return returnMessage;
            }
        }
    }
}
