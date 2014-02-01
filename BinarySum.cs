using System;
using System.Text;

// You have two numbers decomposed in binary representation, write a function that sums them and returns the result. 

// Input: 100011, 100100 
// Output: 1000111

namespace BinarySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int binary1 = 100011;
            int binary2 = 100100;

            Console.WriteLine("Sum of {0} and {1} is {2}", binary1, binary2, sum(binary1, binary2));
        }

        static int sum(int binary1, int binary2)
        {
            StringBuilder result = new StringBuilder("");
            bool isCarryPresent = false;

            string binary1Str = binary1.ToString();
            string binary2Str = binary2.ToString();

            int current1 = binary1Str.Length - 1;
            int current2 = binary2Str.Length - 1;


            while (current1 >= 0 && current2 >= 0)
            {
                int sum = 0;

                char digit1 = binary1Str[current1];
                char digit2 = binary2Str[current2];

                if (digit1 == '1' && digit2 == '1')
                {
                    sum = isCarryPresent ? 1 : 0;
                    isCarryPresent = true;
                }
                else if ((digit1 == '0' && digit2 == '1') || (digit1 == '1' && digit2 == '0'))
                {
                    sum = isCarryPresent ? 0 : 1;
                }
                else
                {
                    if (isCarryPresent)
                    {
                        sum = 1;
                        isCarryPresent = false;
                    }
                    else
                    {
                        sum = 0;
                    }
                }

                result.Insert(0, sum.ToString());

                current1--;
                current2--;
            }

            if (current1 > 0)
            {
                CopyRemainingBits(binary1Str, current1, isCarryPresent, result);
            }
            else if (current2 > 0)
            {
                CopyRemainingBits(binary2Str, current2, isCarryPresent, result);
            }
            else if (isCarryPresent)
            {
                result.Insert(0, "1");
            }


            return Int32.Parse(result.ToString());
        }

        static void CopyRemainingBits(string binaryInput, int currentIndex, bool isCarryPresent, StringBuilder result)
        {
            while (currentIndex >= 0)
            {
                int sum = 0;

                char digit = result[currentIndex];

                if (digit == '0')
                {
                    if (isCarryPresent)
                    {
                        sum = 1;
                        isCarryPresent = false;
                    }
                    else
                    {
                        sum = 0;
                    }
                }
                else
                {
                    sum = isCarryPresent ? 0 : 1;
                }

                result.Insert(0, sum.ToString());

                currentIndex--;
            }

            if (isCarryPresent)
            {
                result.Insert(0, "1");
            }
        }
    }
}
