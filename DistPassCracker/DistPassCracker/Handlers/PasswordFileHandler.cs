using System;
using System.Collections.Generic;
using System.IO;

namespace DistPassCracker.Handlers
{
    public class PasswordFileHandler
    {
        /// <summary>
        /// Loads in a passwordfile by filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<EncryptedUserInfo> ReadPasswordFile(string filename)
        {
            List<EncryptedUserInfo> result = new List<EncryptedUserInfo>();

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(":".ToCharArray());
                    EncryptedUserInfo usrinf = new EncryptedUserInfo(parts[0], parts[1]);
                    result.Add(usrinf);
                }
                return result;
            }
        }


        public void PossiblePasswordsLogger<T>(List<T> result)
        {
            var results = new List<string>();
            //var path = ""; //Use generic filepath
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments); //For Windows. Saves OutputFile in Documents
            //This WILL fail. We need to find a way to get permissions to write a file to windows documents.. or something.. see if i care.

            using (var OutputFile = new StreamWriter(@path))
            {
                Console.WriteLine("Writing results to ", path);
                foreach (var l in results)
                {
                    OutputFile.WriteLine(l);
                }
            }
        }
    }
}