using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceSpaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // string input = "ae r t    "; // length = 6
            //ae%20r%20t // length = 10


            string input = "I am  "; // length = 4
            // I%20am // length = 6

            int trueLength = "I am".Length;
            replaceSpaces(input.ToArray(), trueLength);
        }

        static void replaceSpaces(char[] str, int length)
        {
            int spaceCount = 0, newLength, i = 0;

            for (i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            newLength = length + spaceCount * 2;

            // str[newLength] = '\0';

            for (i = length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[newLength - 1] = '0';
                    str[newLength - 2] = '2';
                    str[newLength - 3] = '%';
                    newLength -= 3;
                }
                else
                {
                    str[newLength - 1] = str[i];
                    newLength -= 1;
                }
            }

            String result = new String(str);
            Console.WriteLine("Output is {0}", result);
        }            
    }
}
