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

        //private static Random rng = new Random();

        public static List<string> DictList;

        public static List<string> PartialListOne;
        public static List<string> PartialListTwo;
        public static List<string> PartialListThree;
        public static List<string> PartialListFour;
        public static List<string> PartialListFive;

        private static readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ".ToCharArray();



        public DictionaryHandler()
        {
            DictList = new List<string>(File.ReadAllLines("webster-dictionary"));
        }

        public static List<string> ListSplitter(List<string> dictionary)
        {
            int x = 0;
            for (int i = 0; i < dictionary.Count; i++)
            {
                ++x;
                if (dictionary[i].StartsWith(Alphabet[x].ToString()) || x >= Alphabet.Length) LetterQuery(Alphabet[x]);
                if (x == Alphabet.Length) break;
            }
            return null;
        }

        private static List<string> LetterQuery(char letter)
        {
            List<string> Result = new List<string>();
            var query = DictList.Where(x => x.StartsWith(letter.ToString()));
            foreach (var item in query) Result.Add(item);
            return Result;
        }

//        public static void Shuffle<T>(IList<T> list)
//        {
//            int n = list.Count;
//            while (n > 1)
//            {
//                n--;
//                int k = rng.Next(n + 1);
//                T value = list[k];
//                list[k] = list[n];
//                list[n] = value;
//            }
//        }
    }
}