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

            Artist Marvin = new Artist("Marvin");
            Artist Arnold = new Artist("Arnold");

        }

        public static int TestMethod(string testString)
        {
            return 42;
        }

        public class Artist
        {
            public delegate int ArtistsEventHandler(object o, EventArgs a);
            public event ArtistsEventHandler ReceiveOscar;

            public string name { get; set; } = "Default";
            
            public Artist(string newName)
            {

            }


        }


    }
}
