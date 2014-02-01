using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given an integer array and a positive integer k, count all distinct pairs with difference equal to k.

//Examples:

//Input: arr[] = {1, 5, 3, 4, 2}, k = 3
//Output: 2
//There are 2 pairs with difference 3, the pairs are {1, 4} and {5, 2} 

//Input: arr[] = {8, 12, 16, 4, 0, 20}, k = 4
//Output: 5
//There are 5 pairs with difference 4, the pairs are {0, 4}, {4, 8}, 
//{8, 12}, {12, 16} and {16, 20}

namespace PairsWithKDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3;
            int[] input1 = { 1, 5, 3, 4, 2 };
            Console.WriteLine("Count of pairs for input1 is {0}", countPairsWithDiffk1(input1, k));

            int[] input2 = { 8, 12, 16, 4, 0, 20 };
            k = 4;
            Console.WriteLine("Count of pairs for input2 is {0}", countPairsWithDiffk1(input2, k));

            int[] input3 = { -1, 2, 7, -8, 4, -5 };
            k = 3;
            Console.WriteLine("Count of pairs for input3 is {0}", countPairsWithDiffk1(input3, k));
        }

        // Approach 1
        // Time -  O(n * n)
        // Space - O(1)
        static int countPairsWithDiffk1(int[] input, int k)
        {
           int count = 0;

           for(int i = 0; i < input.Length; i++)
           {
               for(int j = i + 1; j < input.Length; j++)
               {
                   if ((input[i] - input[j] == k) || (input[j] - input[i] == k))
                   {
                       count++;
                   }
               }
           }

           return count;
        }

        // Approach 2
        static int countPairsWithDiffk2(int[] input, int k)
        {
            HashSet<int> set = new HashSet<int>(input);

            int count = 0;

            foreach (int value in set)
            {
                if (set.Contains(k + value))
                {
                    count++;
                }
            }

            return count;
        }

    }
}
