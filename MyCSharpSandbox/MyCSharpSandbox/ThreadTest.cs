using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCSharpSandbox
{
    class ThreadTest
    {
        public static Thread MyThread = new Thread(MyStaticMethod);
        public static Thread MyOtherThread = new Thread(MyOtherStaticMethod);


        public static void Start()
        {
            Thread.Sleep(500);
            Console.WriteLine("Hello World");
            MyThread.Start();
            MyOtherThread.Start();

            Console.WriteLine("Thread A is ThreadPool? : " + MyThread.IsThreadPoolThread);
            Console.WriteLine("Thread B is ThreadPool? : " + MyOtherThread.IsThreadPoolThread);

            MyThread.Join();
            MyOtherThread.Join();
        }

        public static void MyStaticMethod()
        {
            // do it
            for (int c = 0; c < 256; c++)
            {
                char myChar = (char)c;
                Console.Write(myChar);
                Thread.Sleep(10);
            }
        }

        public static void MyOtherStaticMethod()
        {
            // do it
            for (int i = 0; i < 256; i++)
            {
                Console.Write(i +":");
                Thread.Sleep(10);
            }
        }
    }
}
