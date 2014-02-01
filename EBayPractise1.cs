// Given a sorted integer array and a number, find the start and // end indexes of n in the array.
// e.g. {0,0,1,1,1,5,5,6,6,6,6,7,11}, n = 5 -> output {5,6}
// Follow up: Can you get it to be < O (n)

// Best case log(n) solution below. Worst case is stil O(n)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayPractise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = -1;
            int end = -1;

            int[] input = new int[]{2, 3, 4, 4, 4, 5, 5, 5, 5, 5, 7, 7};
            // int[] input = new int[] { 0, 0, 1, 1, 1, 5, 5, 6, 6, 6, 6, 7, 11 };
            int number = 5;

            FindIndices(input, number, ref begin, ref end);

            Console.WriteLine("Begin is {0} and end is {1}", begin, end);
        }

        static void FindIndices(int[] input, int number, ref int begin, ref int end)
        {
            FindIndicesHelper(input, number, ref begin, ref end, 0, input.Length - 1);
        }

        static void FindIndicesHelper(int[] input, int number, ref int begin, ref int end, int first, int last)
        {
            if (first > last)
            {
                return;
            }
            else if ((last - first) == 1)
            {
                if (input[first] == number && input[last] == number)
                {
                    begin = first;
                    end = last;
                }
                else if (input[first] == number)
                {
                    begin = first;
                    end = first;
                }
                else if (input[last] == number)
                {
                    begin = last;
                    end = last;
                }
            }
            else
            {
                int middleIndex = (first + last) / 2;

                int beginTemp = 0;

                if (input[middleIndex] == number)
                {
                    beginTemp = middleIndex;

                    int beginLeft = -1;
                    int endLeft = -1;

                    int beginRight = -1;
                    int endRight = -1;

                    FindIndicesHelper(input, number, ref beginLeft, ref endLeft, first, middleIndex - 1);

                    if (beginLeft != -1)
                    {
                        begin = beginLeft;
                    }
                    else 
                    {
                        begin = beginTemp;
                    }

                    FindIndicesHelper(input, number, ref beginRight, ref endRight, middleIndex + 1, last);

                    if (endRight != -1)
                    {
                        end = endRight;
                    }
                    else
                    {
                        end = beginTemp;
                    }
                }
                else if (input[middleIndex] < number)
                {
                    FindIndicesHelper(input, number, ref begin, ref end, middleIndex + 1, last);
                }
                else
                {
                    FindIndicesHelper(input, number, ref begin, ref end, first, middleIndex - 1);
                }
            }
        }
    }
}
