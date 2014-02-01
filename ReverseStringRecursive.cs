
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "gappu";
            string input = "interview";
            Console.WriteLine("Reverse of {0} is {1}", input, Reverse(input));

		Revers(input, 0, new StringBuild());
        }

        static string Reverse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
               return null; 
            }
            else if (s.Length == 1)
            {    
               return s;
            }
            else
            {
               char firstChar = s[0];
               string result = Reverse(s.Substring(1, s.Length - 1));
               return result + firstChar;
            }
        }


        //cat n = 0 sb = tac 
        //cat n = 1 sb = ta
        //cat n = 2 sb = t 
        //cat n = 3 sb = ""
                      
	string ReverseRecurs(String s, int n, StringBuilder sb)
	{

		if (n == s.length)
		   return "";

		ReverseRecurs(s, n+1, sb);

		sb.Append(s[n]);

		return sb.ToString();
       }
    }
}
