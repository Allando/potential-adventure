using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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
            //Maybe utilizing something like the ThreadHandler here would be viable?

            //Registering start time, and end time
            DateTime startTime =  DateTime.Now;
            /*
            These needs to be seperated by the cracking method, and then measured up against eachother
            this way we make figure out exactly how long it took the cracking method to run.
            */
            DateTime endTime = DateTime.Now;
            string timeTaken = TimeCalculation(startTime, endTime);

        }

        private static bool CompareBytes(IList<byte> firstArray, IList<byte> secondArray)
        {
            if (firstArray.Count != secondArray.Count) return false;
            for (int i = 0; i < firstArray.Count; i++)
            {
                if (firstArray[i] != secondArray[i]) return false;
            }
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