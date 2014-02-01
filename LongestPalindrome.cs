using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            // string input = "aaaabbdddddd";
            // string input = "aaab";
            string input = "aaabbaaaccdeqjncsdddmmmkkkmmmddd";
            Console.WriteLine("The longest palindrome is {0}", GetLongestPalindrome(input));
        }

        static string GetPalindromeFromCenter(int lower, int upper, string input)
        {
            string result = null; 

            while (lower >= 0 && upper < input.Length)
            {
                if (input[lower] == input[upper])
                {
                    result = input.Substring(lower, upper - lower + 1);
                }
                else
                {
                    break;
                }

                lower--;
                upper++;
            }

            return result;
        }

        static string GetLongestPalindrome(string input)
        {
            string longestPalindrome = input[0].ToString();

            for (int i = 0; i < input.Length - 1; i++)
            {
                string palindromeCandidate1 = GetPalindromeFromCenter(i, i + 1, input);

                if (!string.IsNullOrEmpty(palindromeCandidate1) && (palindromeCandidate1.Length > longestPalindrome.Length))
                {
                    longestPalindrome = palindromeCandidate1;
                }

                string palindromeCandidate2 = GetPalindromeFromCenter(i, i, input);

                if (!string.IsNullOrEmpty(palindromeCandidate2) && (palindromeCandidate2.Length > longestPalindrome.Length))
                {
                    longestPalindrome = palindromeCandidate2;
                }
            }

            return longestPalindrome;
        }
    }
}
