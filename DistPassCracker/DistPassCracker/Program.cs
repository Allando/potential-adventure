using System;
using System.Collections;
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

            //Task Example
//            Task t = Task.Run(() =>
//            {
//                CrackerThread();
//            });

//            Task[] tasks = new Task[3];
//            for (int i = 0; i < 3; i++)
//            {
//                tasks[i] = Task.Run(() => Console.WriteLine($"Task {i} has finished successfully"));
//            }
//            int x = 0;
//            Task[] ts = new Task[10];
//            for (int i = 0; i < 10; i++)
//            {
//                ts[i] = Task.Run(() => CrackerMethod(i));
//                ts[i].Wait();
//                x = i;
//            }
//            Console.WriteLine(x);

//            foreach (var i in DictionaryHandler.DictList)
//            {
//                Console.WriteLine(i);
//            }

            DictionaryHandler.SplitDict();

//            ThreadStart t = new ThreadStart(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[0]));
//            ThreadStart t1 = new ThreadStart(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[1]));
//            ThreadStart t2 = new ThreadStart(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[2]));
//            ThreadStart t3 = new ThreadStart(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[3]));
//
//
//
//
//            Thread tt = new Thread(t);
//            Thread tt1 = new Thread(t1);
//            Thread tt2 = new Thread(t2);
//            Thread tt3 = new Thread(t3);

//
//            int x = 0;
//            for (int i = 0; i < DictionaryHandler.chunckCollection[1].Count; i++) if (DictionaryHandler.chunckCollection[0][i] == DictionaryHandler.chunckCollection[1][i]) x++;
//            Console.WriteLine($"{x} Identical words out of {DictionaryHandler.chunckCollection[0].Count}");

//            Task task1 = Task.Run(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[0]));
//            Task task2 = Task.Run(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[1]));
//            Task task3 = Task.Run(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[2]));
//            Task task4 = Task.Run(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[3]));
//
//            task1.Wait();
//            task2.Wait();
//            task3.Wait();
//            task4.Wait();

//            Console.WriteLine(DictionaryHandler.chunckCollection.Count);
//            List<Task> tasks = new List<Task>();
//            for (int i = 0; i < DictionaryHandler.chunckCollection.Count; i++)
//            {
//                tasks.Add(Task.Run(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[i])));
//            }

//            foreach (var task in tasks)
//            {
////                task.Wait();
//
//                Console.WriteLine(tasks.Count);
//            }

//            Task.WaitAll(tasks.ToArray());
            DateTime startTime =  DateTime.Now;


            ThreadStart[] threadStarts = new ThreadStart[DictionaryHandler.chunckCollection.Count];
            for (int i = 0; i < DictionaryHandler.chunckCollection.Count; i++)
            {
                threadStarts[i] = new ThreadStart(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[i]));
                new Thread(threadStarts[i]).Start();
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine(CrackingHandler.TimeCalculation(startTime, endTime));
            Console.WriteLine($"Found {CrackingHandler.PassCount} of {12}");
            Console.WriteLine("Done");
        }
    }
}
