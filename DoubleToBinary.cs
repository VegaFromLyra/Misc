using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Question 1: Given a real number between 0 and 1 (0.72) that is passed in as a double, print the binary representation
// If the number cannot be represented accurately in at most 32 characters, print "ERROR"


// Question 2: convert a binary string into double

namespace DoubleToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = 0.75;
            Console.WriteLine("Binary form of {0} is ", num);
            PrintBinaryForm(num);

            string binary = "101.11";
            Console.WriteLine("Double value of {0} is {1}", binary, ConvertBinaryToDouble(binary));
        }

        static void PrintBinaryForm(double numToConvert)
        {
            StringBuilder sb = new StringBuilder("0.");

            while (numToConvert > 0)
            {
                if (sb.Length >= 32)
                {
                    Console.WriteLine("ERROR");
                    return;
                }

                numToConvert *= 2;

                if (numToConvert >= 1)
                {
                    sb.Append("1");
                    numToConvert -= 1;
                }
                else
                {
                    sb.Append("0");
                }
            }


            Console.WriteLine(sb.ToString());
        }

        static double ConvertBinaryToDouble(string binary)
        {
            if (String.IsNullOrEmpty(binary))
            {
                throw new Exception("Invalid input");
            }
            
            string leftDecimal = null;
            string rightDecimal = null;

            if (binary.Contains('.'))
            {
                string[] splitResult = binary.Split('.');
                leftDecimal = splitResult[0];
                rightDecimal = splitResult[1];
            }
            else
            {
                leftDecimal = binary;
            }

            double leftDecimalValue = 0;
            double rightDecimalValue = 0;

            if (!String.IsNullOrEmpty(leftDecimal))
            {
                for (int i = 0; i < leftDecimal.Length; i++)
                {
                    leftDecimalValue +=  Double.Parse(leftDecimal[i].ToString()) * Math.Pow(2, leftDecimal.Length - 1 - i);
                }
            }

            if (!String.IsNullOrEmpty(rightDecimal))
            {
                for (int i = 0; i < rightDecimal.Length; i++)
                {
                    rightDecimalValue += Double.Parse(rightDecimal[i].ToString()) * (1/Math.Pow(2, (i + 1)));
                }
            }

            return leftDecimalValue + rightDecimalValue;
        }
    }
}
