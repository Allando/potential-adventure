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
        public static List<Userinfo> ReadPasswordFile(string filename)
        {
            List<Userinfo> result = new List<Userinfo>();

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(":".ToCharArray());
                    Userinfo usrinf = new Userinfo(parts[0], parts[1]);
                    result.Add(usrinf);
                }
                return result;
            }
        }
    }
}