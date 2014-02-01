using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] result = FindPrimeList(25);

            for(int i = 0; i < result.Length; i++)
            {
                if (result[i])
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool[] FindPrimeList(int max)
        {
            if (max < 0)
            {
                throw new Exception("Input must be non negative");
            }

            bool[] result = new bool[max + 1];

            Initialize(result);

            int prime = 2;

            while (prime <= max)
            {
                crossOff(result, prime);

                prime = getNextPrime(result, prime);
            }

            return result;
        }



        static void Initialize(bool[] result)
        {
            if (result.Length > 2)
            {
    	        result[0] = false;
                result[1] = false; 

                for(int i = 2; i < result.Length; i++)
                {
                    result[i] = true;
                }
             }
             else
             {
                 for (int i = 0; i < result.Length; i++)
                 {
                     result[i] = false;
                 }
             }
        }

        static void crossOff(bool[] result, int prime)
        {
            // Cross off all multiples of prime but not prime itself

            for (int i = 2; (i * prime) < result.Length; i++)
            {
                result[i * prime] = false;
            }
        }

        static int getNextPrime(bool[] primeArray, int currentPrime)
        {
            int next = currentPrime + 1;

            for (int i = next; i < primeArray.Length; i++)
            {
                if (primeArray[i])
                {
                    return i;
                }
            }

            return primeArray.Length;
        }
    }
}
