﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DistPassCracker.Handlers;

namespace DistPassCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Threading example
//            ThreadStart crackValThread1 = new ThreadStart(CrackerThread);
//            Console.WriteLine("Thread Created");
//            Thread crack1Child = new Thread(crackValThread1);
//            crack1Child.Name = "thread1";
//            crack1Child.Start();
//            Console.WriteLine($"Thread {crack1Child.Name} has been started");
//            Console.ReadKey();

//            DateTime start = DateTime.Now;
//            DateTime end = new DateTime(2017, 3, 5, 14, 45, 30);
//
//            CrackingHandler cracker = new CrackingHandler();
//            Console.WriteLine(cracker.TimeCalculation(start, end));
//            Console.ReadKey();
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
