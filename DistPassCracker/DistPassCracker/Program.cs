using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DistPassCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Threading example
            ThreadStart crackValThread1 = new ThreadStart(CrackerThread);
            Console.WriteLine("Thread Created");
            Thread crack1Child = new Thread(crackValThread1);
            crack1Child.Name = "thread1";
            crack1Child.Start();
            Console.WriteLine($"Thread {crack1Child.Name} has been started");
            Console.ReadKey();
        }

        //Test method
        static void CrackerThread()
        {
            //TEST af thread component.
            //TODO: Functionality, basically doing some dictionary handling and so on.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Womble is a faggot");
            }
        }
    }
}
