using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class HideBehindInterface
    {
        public static void Start()
        {
            Robot Generic = new Robot();

            ISafeForKids TubbieBot = new Robot();
            TubbieBot.PlayGame();
            TubbieBot.TellAStory();

            IMilitaryOperations T1000 = new Robot();
            T1000.SeekAndDestroy("Roger Wilco");
            T1000.SelfDestruct(5);

            IMixedOperations Marvin = new Robot();
            Marvin.PlayGame();
            Marvin.SelfDestruct(10);
        }

        interface ISafeForKids
        {
            void PlayGame();
            void TellAStory();
        }

        interface IMilitaryOperations
        {
            void SeekAndDestroy(string newTarget);
            void SelfDestruct(int countdown);
        }

        interface IMixedOperations
        {
            void PlayGame();
            void SelfDestruct(int countdown);
        }

        public class Robot : ISafeForKids, IMilitaryOperations, IMixedOperations
        {
            public string name { get; private set; }
            public int id { get; private set; }

            public void PlayGame()
            {
                Console.WriteLine("Ok ... let's play a game!");
            }
            public void TellAStory()
            {
                Console.WriteLine("Ok ... I will tell you a story!");
            }
            public void SeekAndDestroy(string newTarget)
            {
                Console.WriteLine("ROGER! LOOKING FOR TARGET "+newTarget);
            }
            public void SelfDestruct(int countdown)
            {
                Console.WriteLine("ROGER! GETTING READY FOR SELF DESTRUCTION in T-{0}", countdown);
            }
        }

    }
}
