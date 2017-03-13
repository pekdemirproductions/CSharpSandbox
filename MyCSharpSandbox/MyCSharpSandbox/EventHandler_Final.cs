using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    class EventHandler_Final
    {
        public class ArtistEventArgs : EventArgs
        { public string ArtistMessage; }

        public static void Start()
        {
            // ============= Artist Creation =============
            Artist DiCaprio = new Artist("Leonardo DiCaprio");
            Artist DeNiro = new Artist("Robert De Niro");

            // ============= PUBLISHER =============
            Reporter LATimes = new Reporter("L.A. Times");

            // ============= Event-Registration =============
            DiCaprio.ReceiveOscar += LATimes.PublishNews;
            DeNiro.ReceiveOscar += LATimes.PublishNews;

            // ============= Make Artists Work =============
            DiCaprio.WorkOnOscar();
            DeNiro.WorkOnOscar();
        }

        public class Artist
        {
            // ============= Create Delegate & Event Handler =============
            public delegate void ArtistsEventHandler(object o, ArtistEventArgs a);
            public event ArtistsEventHandler ReceiveOscar;

            public string name { get; private set; }
            public Artist() { name = "Default"; }
            public Artist(string newName) { name = newName; }

            // ============= WORKHORSE METHOD =============
            public void WorkOnOscar()
            {
                Thread.Sleep(1000);
                ArtistEventArgs EA = new ArtistEventArgs();

                // ============= RAISE EVENT =============
                OnOscarWon(this, EA);
            }

            protected virtual void OnOscarWon(object o, ArtistEventArgs EA)
            {
                if (ReceiveOscar != null)
                    EA.ArtistMessage = string.Format($"Oscar won by {this.name}!");
                // ============= FIRE EVENT =============
                ReceiveOscar(this, EA);
            }
        }

        public class Reporter
        {
            public string name { get; set; }

            public Reporter(string newName) { name = newName; }

            public void PublishNews(object o, ArtistEventArgs AEA)
            {
                Console.WriteLine(AEA.ArtistMessage);
            }
        }
    }
}
