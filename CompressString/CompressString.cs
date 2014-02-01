using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressString
{
    class Program
    {
        static void Main(string[] args)
        {
            // string input = "aabcccccaaa";
            string input = "aaaabbc";

            // Console.WriteLine("Compressing {0} gives {1}", input, Compress1(input));
            // Console.WriteLine("Compressing {0} gives {1}", input, Compress2(input));
            Console.WriteLine("Compressing {0} gives {1}", input, Compress1(input));
            //Console.WriteLine("Compressing {0} gives {1}", input, Compress2(input));
        }

        // Less optimal
        static string Compress1(string input)
        {
            StringBuilder sb = new StringBuilder("");

            int start = 0;
            int count = 0;

            while (start < input.Length)
            {
               count = 1;

               sb.Append(input[start]);

               // Now find how many times this character occurs 
               // and then find the new start value
 
               while ((start + 1) < input.Length && input[start] == input[start + 1])
               {
                   count++;
                   start++;
               }

               sb.Append(count.ToString());

               start += 1;
            }

            if (sb.Length < input.Length)
            {
                return sb.ToString();
            }

            return input;
        }

        // More optimal
        static string Compress2(string input)
        {
            int compressedSize = GetCompressedSize(input);

            if (compressedSize > input.Length)
            {
                return input;
            }

            StringBuilder sb = new StringBuilder("");

            char last = input[0];
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == last)
                {
                    count++;
                }
                else
                {
                    sb.Append(last);
                    sb.Append(count.ToString());
                    last = input[i];
                    count = 1;
                }
            }


            sb.Append(last);
            sb.Append(count.ToString());

            return sb.ToString();
        }

        static int GetCompressedSize(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new Exception("Invalid input");
            }

            int count = 1;
            int size = 0;
            char last = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == last)
                {
                    count++;
                }
                else
                {
                    last = input[i];
                    size += 1 + count.ToString().Length ; // size = current character + sizeof(count)
                    
                    //reset count
                    count = 1;
                }
            }

            return size;
        }
    }
}
