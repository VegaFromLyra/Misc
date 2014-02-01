using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestAndLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 6;
            // Solution 1
            // PrintSmallestAndLargest(num);

            // Solution 2
            Console.WriteLine("next greatest is {0}", getNextLargest(num));
            Console.WriteLine("next smallest is {0}", getNextSmallest(num));
        }

        // Given a postive integer, print the next smallest and next largest number 
        // that have the same number of 1's

        // Brute force approach

        static void PrintSmallestAndLargest(int n)
        {
           int numberOfOnes = GetNumberOfOnes(n);

           bool done = false;

           int currentN = n;
           while (!done)
           {
               currentN++;
               if (GetNumberOfOnes(currentN) == numberOfOnes)
               {
                   Console.WriteLine("Next largest number is {0}", currentN);
                   done = true;
               }
           }

           currentN = n;
           done = false;

           while (!done)
           {
                currentN--;
                if (currentN == 0)
                {
                    Console.WriteLine("Next smallest number is {0}", n);
                    done = true;
                }
                else
                {
                    if (GetNumberOfOnes(currentN) == numberOfOnes)
                    {
            	        Console.WriteLine("Next smallest number is {0}", currentN);
            	        done = true;                 
                    }
                }       
           }
        }

        static int GetNumberOfOnes(int num)
        {
            int count = 0;

            while (num > 0)
            {
                if ((num & 1) == 1)
                {
                    count++;
                }

                num = num >> 1;
            }

            return count;
        }

        // Solution - 2, using bit manipulation

        static int getNextLargest(int n)
        {
            int c0 = 0;
            int c1 = 0;
            int c = 0;

            // To get next largest, we need to 
            // flip the rightmost non trailing 0 to a 1
            // c1 is the number of 1's to the right of the rightmost non trailing 0
            // after flipping, add back c1 - 1 ones from the right

            // 0110 - 6 - n
            // 1001 - 9 - next largest number

            c = n;

            // c0 = number of trailing of 0's
            while ((c & 1) == 0 && c != 0)
            {
                c0++;
                c >>= 1;
            }

            // c1 = number of 1's to the left of the trailing 0's
            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            if ((c0 + c1 == 0) || (c0 + c1 == 32))
            {
                Console.WriteLine("No bigger number found");
                return -1;
            }

            int p = c0 + c1;

            // flip the 0 at p position
            n |= (1 << p);

            // clear bits to the right of p
            n &= ~((1 << p) - 1);

            // now add c1 - 1 1's 
            n |= ((1 << c1 - 1) - 1);

            return n;
        }

        static int getNextSmallest(int n)
        {
            // To get next smallest, we first need to flip a 1 to a 0 and then a 0 to a 1
            // c1 = trailing 1's
            // c0 = block of 0's to the left of trailing 1's
            // p = c0 + c1
            // Flip the 1 at p to a 0
            // add c1 + 1 1's to the immediate right of p
            // The (c1 + 1) block of 1's will be left shifted by (c0 - 1) to satisy the condition
            // p = c0 + c1

            int c1 = 0;
            int c0 = 0;
            int c = n;

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            if (c == 0)
            {
                Console.WriteLine("No smaller number found");
            }

            while ((c & 1) == 0 && (c != 0))
            {
                c0++;
                c >>= 1;
            }

            int p = c0 + c1;
            
            // clear bits 0 through p
            n &= ~((1 << (p + 1)) - 1);

            // 0001 1001 clear bits 0 through 2 
            // p = 2
            // 0000 1000 1 << (p + 1)
            // 0000 0111 (1 << (p + 1)) - 1
            // 1111 1000
 
            // make mask of c1 + 1 ones
            int mask = (1 << (c1 + 1)) - 1; // mask of (c1 + 1) 1's

            n |= mask << (c0 - 1);

            return n;
        }

    }
}
