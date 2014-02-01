using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4};

            int begin = 0;
            int end = 0;

            Console.WriteLine("The maximum sum is: {0}", FindMaximumContiguousSum(input, ref begin, ref end));

            Console.WriteLine("Start index is: {0}", begin);

            Console.WriteLine("End index is: {0}", end);
        }

        static int FindMaximumContiguousSum(int[] input, ref int begin, ref int end)
        {
            if (AllNegative(input))
            {
               return FindLargestNegativeNumber(input, begin, end);
            }
 
            int max_so_far = input[0];
            int max_ending_here = input[0]; 

            int begin_temp = 0;
 
            for(int i = 1; i < input.Length; i++)
            {        
                if (max_ending_here < 0)
                {
                    max_ending_here = input[i]; 
                    begin_temp = i; 
                }
                else 
                {
                    max_ending_here += input[i];    
                }

                if (max_ending_here > max_so_far)
                {
                    max_so_far = max_ending_here;
                    begin = begin_temp;
                    end = i; 
                }
            }

            return max_so_far; 
        }

        bool AllNegative(int[] input)
        {
           for(int i = 0; i < input.Length; i++)
           {
              if (input[i] >= 0)
              {
                  return false;
              }
           }

           return true;
        }

        int FindLargestNegativeNumber(int[] input, ref int begin, ref int end)
        {
            int max = input[0];

            for(int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }
            }

            return max;
        }

    }
}
