﻿using System;
using System.Linq;
using System.Text;

namespace DistPassCracker.Handlers
{
    public class StringUtility
    {
        /// <summary>
        /// Capitalizes the inputtet string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Capitalize(string str)
        {
            if (str == null) throw new ArgumentNullException("str");
            if (str.Trim().Length == 0) return str;

            string firstLetterUppercase = str.Substring(0, 1).ToUpper();
            string theRest = str.Substring(1);

            return firstLetterUppercase + theRest;
        }
        /// <summary>
        /// Reverses the inputtet string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Reverse(string str)
        {
            if (str == null) throw new ArgumentNullException("str");
            if (str.Trim().Length == 0) return str;

            StringBuilder reverseString = new StringBuilder();

            for (int i = 0; i < str.Length; i++) reverseString.Append(str.ElementAt(str.Length - 1 - i));
            return reverseString.ToString();
        }
    }
}