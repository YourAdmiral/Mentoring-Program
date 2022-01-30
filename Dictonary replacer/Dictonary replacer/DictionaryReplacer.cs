using System;
using System.Collections.Generic;

namespace Dictonary_replacer
{
    public static class DictionaryReplacer
    {
        public static string Replace(string str, Dictionary<string, string> dictionary)
        {
            if (str == null || dictionary == null)
            {
                throw new ArgumentNullException();
            }

            if (String.IsNullOrEmpty(str) || dictionary.Count == 0)
            {
                return str;
            }
            else
            {
                foreach (var pair in dictionary)
                {
                    str = str.Replace($"${pair.Key}$", pair.Value);
                }
            }

            return str;
        }
    }
}
