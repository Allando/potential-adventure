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

        //public static List<string> DictList = new List<string>(File.ReadAllLines("/Users/TRiBByX/RiderProjects/DistPassCracker/DistPassCracker/webster-dictionary.txt"));
        public static List<string> DictList = new List<string>(File.ReadAllLines("/home/theippo1000/Programming/Repos/potential-adventure/DistPassCracker/webster-dictionary.txt"));


        public static List<string> PartialListOne;
        public static List<string> PartialListTwo;
        public static List<string> PartialListThree;
        public static List<string> PartialListFour;
        public static List<string> PartialListFive;

        private static readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ".ToCharArray();

        /// <summary>
        /// Splits a list into 5 lists. You access these by calling DictionaryHandler.PartialListOne/Two/Three and so on.
        /// Takes a string list as parameter.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Finds all entries with the letter specified in the parameter
        /// Takes a char as parameter.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        private static List<string> LetterQuery(char letter)
        {
            List<string> Result = new List<string>();
            var query = DictList.Where(x => x.StartsWith(letter.ToString()));
            foreach (var item in query) Result.Add(item);
            return Result;
        }
    }
}