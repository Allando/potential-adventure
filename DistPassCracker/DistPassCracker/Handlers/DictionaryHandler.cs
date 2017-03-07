﻿using System;
using System.Collections;
using System.Collections.Generic;
 using System.Collections.ObjectModel;
 using System.IO;
using System.Linq;

namespace DistPassCracker.Handlers
{
    public class DictionaryHandler
    {
        //TODO: Handle how the dictionary is split and distributed.

        private static List<string> DictList = new List<string>(File.ReadAllLines("webster-dictionary.txt"));
        public static Collection<List<string>> chunckCollection = new Collection<List<string>>();



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
                if (dictionary[i].StartsWith(Alphabet[x].ToString()) || x >= Alphabet.Length)
                {
                    List<string> result = LetterQuery(Alphabet[x]);
                }
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
            List<string> result = new List<string>();
            var query = DictList.Where(x => x.StartsWith(letter.ToString()));
            foreach (var item in query) result.Add(item);
            return result;
        }

        public static Collection<List<string>> SplitDict()
        {
            int maxChunckSize = DictList.Count / 4;
            int n = 1;
            List<string> chunck = new List<string>();
            foreach (var word in DictList)
            {
                chunck.Add(word);
                if (n++ % maxChunckSize == 0)
                {
                    chunckCollection.Add(chunck);
                    chunck = new List<string>();
                }
                chunckCollection.Add(chunck);
            }
            return chunckCollection;
        }
    }
}