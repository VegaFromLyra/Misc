using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "dog";

            string s2 = "god";

            bool result = IsAnagram2(s1, s2);

            Console.WriteLine("Result is {0}", result);
        }

        static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            char[] s1Array = s1.ToArray();
            Array.Sort(s1Array);

            char[] s2Array = s2.ToArray();
            Array.Sort(s2Array);

            string s1Sorted = new string(s1Array);

            string s2Sorted = new string(s2Array);

            return (s1Sorted.CompareTo(s2Sorted) == 0);
        }

        static bool IsAnagram2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            Dictionary<char, int> table = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (table.ContainsKey(s1[i]))
                {
                    table[s1[i]]++;
                }
                else
                {
                    table[s1[i]] = 1;
                }
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (table.ContainsKey(s2[i]))
                {
                    table[s1[i]]--;
                }
            }

            foreach (KeyValuePair<char, int> entry in table)
            {
                if (entry.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
