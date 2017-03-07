using System;
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
        //Variable to store what type of hash method has beeh used for hashing.
        private readonly HashAlgorithm _messageHashAlgorithm;

        /// <summary>
        /// Constructor for the cracking handler.
        /// </summary>
        public CrackingHandler()
        {
            //Other algorithms could be chosen here, like MD5 or SHA256
            _messageHashAlgorithm = new SHA1CryptoServiceProvider();
            //_messageHashAlgorithm = new SHA256CryptoServiceProvider();
            //_messageHashAlgorithm = new MD5CryptoServiceProvider();
        }

        /// <summary>
        /// Runs the cracking algorithm.
        /// </summary>
        public void RunCracking()
        {
            //TODO: Implement the cracking method
            //Registering start time, and end time
            DateTime startTime =  DateTime.Now;
            /*
            These needs to be seperated by the cracking method, and then measured up against eachother
            this way we make figure out exactly how long it took the cracking method to run.
            */

            List<EncryptedUserInfo> usrInf = PasswordFileHandler.ReadPasswordFile("/Users/TRiBByX/RiderProjects/DistPassCracker/DistPassCracker/Passwords.txt");

            DateTime endTime = DateTime.Now;
            string timeTaken = TimeCalculation(startTime, endTime);

        }

        /// <summary>
        /// Alters the word in the dictionary then encrypts it, to then compare to the target password.
        /// </summary>
        /// <param name="dictionaryEntry"></param>
        /// <param name="userInfos"></param>
        /// <returns></returns>
        private List<DecryptedUserinfo> CheckWordWithVariations(string dictionaryEntry, List<EncryptedUserInfo> userInfos)
        {
            //TODO: Check whether the password has removed all consonants and vocals.
            List<DecryptedUserinfo> result = new List<DecryptedUserinfo>();


            //Check plain word
            string possiblePassword = dictionaryEntry;
            List<DecryptedUserinfo> partialResult = CheckSingleWord(userInfos, possiblePassword);
            result.AddRange(partialResult);

            //Checks all capital letters.
            possiblePassword = dictionaryEntry.ToUpper();
            partialResult = CheckSingleWord(userInfos, possiblePassword);
            result.AddRange(partialResult);

            //Checks capitalized first letter.
            possiblePassword = dictionaryEntry.First().ToString().ToUpper();
            partialResult = CheckSingleWord(userInfos, possiblePassword);
            result.AddRange(partialResult);

            //Checks a reversed password.
            possiblePassword = ReverseString(dictionaryEntry);
            partialResult = CheckSingleWord(userInfos, possiblePassword);
            result.AddRange(partialResult);

            //Checks if the password has a digit at the end.
            for (int i = 0; i < 100; i++)
            {
                possiblePassword = dictionaryEntry + i;
                partialResult = CheckSingleWord(userInfos, possiblePassword);
                result.AddRange(partialResult);
            }

            //Checks if the password has a digit at the start
            for (int i = 0; i < 100; i++)
            {
                possiblePassword = i + dictionaryEntry;
                partialResult = CheckSingleWord(userInfos, possiblePassword);
                result.AddRange(partialResult);
            }
            //checks if the password has a digit at the end and the start.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    possiblePassword = i + dictionaryEntry + j;
                    partialResult = CheckSingleWord(userInfos, possiblePassword);
                    result.AddRange(partialResult);
                }
            }
            return result;
        }

        private List<DecryptedUserinfo> CheckSingleWord(List<EncryptedUserInfo> userInfos, string possiblePassword)
        {
            char[] charArray = possiblePassword.ToCharArray();
            byte[] passwordAsBytes = Convert.FromBase64CharArray(charArray, 1, charArray.Length);

            byte[] hashedPassword = _messageHashAlgorithm.ComputeHash(passwordAsBytes);

            List<DecryptedUserinfo> results = new List<DecryptedUserinfo>();

            foreach (var encryptedUserInfo in userInfos)
            {
                if (CompareBytes(encryptedUserInfo.EncryptedPass, hashedPassword))
                {
                    results.Add(new DecryptedUserinfo(encryptedUserInfo.Username, possiblePassword));
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
            try
            {
                if (firstArray.Count != secondArray.Count) return false;
                for (int i = 0; i < firstArray.Count; i++)
                {
                    if (firstArray[i] != secondArray[i]) return false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw new NullReferenceException(e.Message);
            }
        }

        private string ReverseString(string s)
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
        public string TimeCalculation(DateTime start, DateTime end)
        {
            TimeSpan elapsedTime = end - start;
            return $"Time taken: {elapsedTime}";
        }
    }
}