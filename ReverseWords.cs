using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWords
{
    // "tom is a cat"
    // "tac a si mot

    // "cat a is tom"

    class Program
    {
        static void Main(string[] args)
        {
            string input = "To be or not to be";

            string reversedInput = Reverse2(input);

            Console.WriteLine("Reversed string is {0}", reversedInput);
        }

        private static string Reverse1(string input)
        {
            string[] words = input.Split(' ');

            return String.Join(" ", words.Reverse());
        }

        static string Reverse2(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            Reverse(sb, 0, sb.Length - 1);

            // Now make a second pass and reverse each individual string

            int leftIndex = 0;
            int rightIndex =  0;
            int delimiter = ' ';

            for (int i = 0; i <= sb.Length; i++)
            {
                if ((i < sb.Length) && (sb[i] != delimiter))
                {
                    rightIndex++;
                }
                else
                {
                    Reverse(sb, leftIndex, rightIndex - 1);
                    leftIndex = i + 1;
                    rightIndex = i + 1;
                }
            }

            return sb.ToString();
        }

        static void Reverse(StringBuilder input, int leftIndex, int rightIndex)
        {
            // Validate leftIndex and rightIndex

            while (leftIndex < rightIndex)
            {
                char temp = input[leftIndex];
                input[leftIndex] = input[rightIndex];
                input[rightIndex] = temp;

                // Swap(input[leftIndex], input[rightIndex]);

                leftIndex++;
                rightIndex--;
            }
        }

        static void Swap(char a, char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

    }
}
