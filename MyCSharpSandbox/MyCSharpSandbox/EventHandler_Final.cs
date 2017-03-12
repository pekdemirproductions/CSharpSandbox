using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    // BAUSTELLE!!!

    class EventHandler_Final
    {

        public static void Start()
        {

            Artist XXX = new Artist();
            Artist Marvin = new Artist("Marvin");
            Artist Arnold = new Artist("Arnold");

            Console.WriteLine("XXX name: "+XXX.name);

        }

        public static int TestMethod(string testString)
        {
            return 42;
        }

        public class Artist
        {
            public delegate int ArtistsEventHandler(object o, EventArgs a);
            public event ArtistsEventHandler ReceiveOscar;

            public string name { get; private set; }
            
            public Artist()
            {
                // Do Nothing
                name = "Default";
            }

            public Artist(string newName)
            {
                name = newName;
            }


        }


    }
}
