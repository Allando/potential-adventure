﻿﻿using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DistPassCracker.Handlers
{
    public class CrackingHandler
    {
        public static int PassCount = 0;
        /// <summary>
        /// Runs the cracking algorithm.
        /// </summary>
        public static void RunCracking(List<string> dictList)
        {
            //Registering start time, and end time
            DateTime startTime =  DateTime.Now;

            List<EncryptedUserInfo> usrInf = PasswordFileHandler.ReadPasswordFile("passwords.txt");

            var Dictionary = dictList;

            //TODO: Fix that it doesnt enter this forloop, and if it does, does so in the wrong way.

            Console.WriteLine("Passwords uploaded");
            for (int i = 0; i < dictList.Count; i++)
            {
                string dicEntry = Dictionary[i];
                List<DecryptedUserinfo> partialResult = CheckWordWithVariations(dicEntry, usrInf);
            }

            //Registering the end time.
            DateTime endTime = DateTime.Now;
            Console.WriteLine(TimeCalculation(startTime, endTime));
            Console.WriteLine($"Found {PassCount} of {usrInf.Count}");
        }

        /// <summary>
        /// Alters the word in the dictionary then encrypts it, to then compare to the target password.
        /// </summary>
        /// <param name="dictionaryEntry"></param>
        /// <param name="userInfos"></param>
        /// <returns></returns>
        private static List<DecryptedUserinfo> CheckWordWithVariations(string dictionaryEntry, List<EncryptedUserInfo> userInfos)
        {
            //TODO: Check whether the password has removed all consonants and vocals.
            List<DecryptedUserinfo> result = new List<DecryptedUserinfo>();

            //Check plain word
            string possiblePassword = dictionaryEntry;
            List<DecryptedUserinfo> partialResult = CheckSingleWord(userInfos, possiblePassword);
            result.AddRange(partialResult);

            //Checks all capital letters.
            string possibleCapitalizedPassword = dictionaryEntry.ToUpper();
            partialResult = CheckSingleWord(userInfos, possibleCapitalizedPassword);
            result.AddRange(partialResult);

            //Checks capitalized first letter.
            string possibleCapitalizedFirstLetterPassword = dictionaryEntry.First().ToString().ToUpper() + dictionaryEntry.Substring(1);
            partialResult = CheckSingleWord(userInfos, possibleCapitalizedFirstLetterPassword);
            result.AddRange(partialResult);

            //Checks a reversed password.
            string possibleReversedPassword = ReverseString(dictionaryEntry);
            partialResult = CheckSingleWord(userInfos, possibleReversedPassword);
            result.AddRange(partialResult);

            //Checks if the password has a digit at the end.
            for (int i = 0; i < 100; i++)
            {
                string possiblePasswordDigit = dictionaryEntry + i;
                partialResult = CheckSingleWord(userInfos, possiblePasswordDigit);
                result.AddRange(partialResult);
            }

            //Checks if the password has a digit at the start
            for (int i = 0; i < 100; i++)
            {
                string possibleDigitPassword = i + dictionaryEntry;
                partialResult = CheckSingleWord(userInfos, possibleDigitPassword);
                result.AddRange(partialResult);
            }
            //checks if the password has a digit at the end and the start.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string possibleDigitPasswordDigit = i + dictionaryEntry + j;
                    partialResult = CheckSingleWord(userInfos, possibleDigitPasswordDigit);
                    result.AddRange(partialResult);
                }
            }
            return result;
        }

        /// <summary>
        /// Checks single password. Converts the possible password to a bytearray and then converts these bytes into their hashes.
        /// Then it compares the two against eachother.
        ///
        /// Takes a list of Encrypted User info and a string of a possible password(non hashed.
        /// </summary>
        /// <param name="userInfos"></param>
        /// <param name="possiblePassword"></param>
        /// <returns></returns>
        private static List<DecryptedUserinfo> CheckSingleWord(List<EncryptedUserInfo> userInfos, string possiblePassword)
        {
            char[] charArray = possiblePassword.ToCharArray();

            byte[] passwordAsBytes = Array.ConvertAll(charArray, StringHandler.GetConverter());

            byte[] hashedPassword = new SHA1CryptoServiceProvider().ComputeHash(passwordAsBytes);

            List<DecryptedUserinfo> results = new List<DecryptedUserinfo>();

            foreach (var encryptedUserInfo in userInfos)
            {
                if (CompareBytes(encryptedUserInfo.EncryptedPass, hashedPassword))
                {
                    results.Add(new DecryptedUserinfo(encryptedUserInfo.Username, possiblePassword));
                    PassCount++;
                    Console.WriteLine($"{encryptedUserInfo.Username} {possiblePassword}");
                }
            }
            return results;
        }

        /// <summary>
        /// Validates whether the password has been found.
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <returns></returns>
        private static bool CompareBytes(IList<byte> firstArray, IList<byte> secondArray)
        {
            if (firstArray.Count != secondArray.Count) return false;
            for (int i = 0; i < firstArray.Count; i++)
            {
                if (firstArray[i] != secondArray[i]) return false;
            }
            return true;
        }

        private static string ReverseString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return chars.ToString();
        }

        /// <summary>
        /// Calculates elapsed time between 2 giving DateTimes. First start then end.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string TimeCalculation(DateTime start, DateTime end)
        {
            TimeSpan elapsedTime = end - start;
            return $"Time taken: {elapsedTime}";
        }
    }
}