using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DistPassCracker.Handlers
{
    public class DictionaryHandler
    {
        //TODO: Handle how the dictionary is split and distributed.

        private static Random rng = new Random();

        public static List<string> DictList;

        public DictionaryHandler()
        {
            DictList = new List<string>(File.ReadAllLines("webster-dictionary"));
        }

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}