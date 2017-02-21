using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static MyCSharpSandbox.RandomTimeBased;

namespace MyCSharpSandbox
{
    class EventHandlerExercise
    {
        public static void Start()
        {

            MissionControl MCAlpha = new MissionControl();
            AirForce AirForceAlpha = new AirForce();
            MCAlpha.EnemySpotted += AirForceAlpha.AirForceEnemyHandler;

            MCAlpha.ControlTowerStart();

        }

        public class MissionControlEventArgs : EventArgs
        {
            public string ImportantMessage;
        }

        public class MissionControl
        {
            public delegate void MissionControlEventHandler(object o, MissionControlEventArgs a);
            public event MissionControlEventHandler EnemySpotted;

            public void ControlTowerStart()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Control Tower here. Scanning for Enemies.");
                    Thread.Sleep(GetRandomNumber(1000, 3000));
                    onEnemySpotted(this, new MissionControlEventArgs() { ImportantMessage = "Test" });
                }
            }

            protected virtual void onEnemySpotted(object o, MissionControlEventArgs args)
            {
                if (EnemySpotted != null)
                    EnemySpotted(this, args);
            }
        }

        public class AirForce
        {
            public void AirForceEnemyHandler(object o, MissionControlEventArgs args)
            {
                Console.WriteLine("Airforce Alarmed! Important Message: " + args.ImportantMessage);
            }
        }
    }
}
