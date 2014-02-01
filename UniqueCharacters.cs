using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueString
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = IsUnique2("abcdefga");

            Console.WriteLine("Result is {0}", result);
        }

        // O(n * n) time O(1) space
        // Could use dictionary for O(1) time and O(n) space
        // Could sort the string and then look for duplicates. Time O(nlogn) and space is O(1) depending on sort algo
        static bool IsUnique(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j].CompareTo(input[i]) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // O(N) time and O(1) space
        // For ASCII characters

        static bool IsUnique2(string input)
        {
            if (input.Length > 256)
            {
                return false;
            }

            bool[] charSet = new bool[256];

            for (int i = 0; i < input.Length; i++)
            {
                int val = input[i];
                if (charSet[val])
                {
                    return false;
                }
                else
                {
                    charSet[val] = true;
                }
            }

            return true;
        }



    }
}
