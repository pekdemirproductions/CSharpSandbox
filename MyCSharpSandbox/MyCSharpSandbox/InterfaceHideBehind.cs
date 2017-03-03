using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class InterfaceHideBehind
    {
        public static void Start()
        {
            SomethingToRead Flyer = new SomethingToRead();

            Book Shining = new Book();
            Shining.Read(30);

            IReadable someReadableInterfaceObject = new Book();
            someReadableInterfaceObject.Read(40);

            Console.WriteLine(someReadableInterfaceObject.ToString());
            Console.WriteLine(Shining.ToString());
            Console.WriteLine(Flyer.ToString());

            GetSomethingToRead(Shining);
            GetSomethingToRead(someReadableInterfaceObject);

        }

        public class SomethingToRead : IReadable
        {
            string topic;
            // Must implement Read for IReadable
            public void Read(int page)
            {
                Console.WriteLine("Now reading page {0} ...", page);
            }
        }

        public class Book : SomethingToRead
        {
            string title;
            int pages;
        }

        public class Dictionary : Book
        {
            string languageA;
            string languageB;
        }

        public interface IReadable
        {
            void Read(int page);
        }

        public static void GetSomethingToRead(IReadable somethingReadable)
        {
            Console.WriteLine("I will now get something to read and check page 50 for you:");
            somethingReadable.Read(50);
        }

    }
}
