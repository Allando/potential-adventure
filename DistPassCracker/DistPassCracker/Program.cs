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
            DictionaryHandler.SplitDict();


            ThreadStart[] threadStarts = new ThreadStart[DictionaryHandler.chunckCollection.Count];
            for (int i = 0; i < DictionaryHandler.chunckCollection.Count; i++)
            {
                threadStarts[i] = new ThreadStart(() => CrackingHandler.RunCracking(DictionaryHandler.chunckCollection[i]));
                new Thread(threadStarts[i]).Start();
            }
            Console.WriteLine(DictionaryHandler.chunckCollection[1].Count);
        }
    }
}
