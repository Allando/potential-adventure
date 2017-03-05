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

        }
    }
}