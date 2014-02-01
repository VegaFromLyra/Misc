using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exponent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0} ^ {1} is {2}", 4, 5, GetExponentialValue3(4, 5));
            Console.WriteLine("{0} ^ {1} is {2}", 3, -1, GetExponentialValue3(3, -1));
        }

        // Time - O(n) - number of multiplications is in the order of power
        // Space - O(1) 
        static double GetExponentialValue1(int x, int n)
        {
            double result = 1;
            bool IsExponentNegative = false;

            if (n < 0)
            {
                IsExponentNegative = true;
                n *= -1;
            }

            for (int i = 1; i <= n; i++)
            {
                result *= x;
            }

            if (IsExponentNegative)
            {
                result = 1 / result;
            }

            return result;
        }


        // Time - O(n) - order is number of function calls = value of power
        // because the time grows linearly with value of 'power'
        static double GetExponentialValue2(int x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                n *= -1;
                return 1 / GetExponentialValue2(x, n);
            }

            return x * GetExponentialValue2(x, n - 1);
        }

        // Compute exponent with log(n) complexity
        static double GetExponentialValue3(int x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                n *= -1;
                return 1 / GetExponentialValue3(x, n);
            }
            else if (n % 2 == 0)
            {
                return GetExponentialValue3(x * x, n / 2);
            }
            else
            {
                return x * GetExponentialValue3(x * x, n / 2);
            }
        }
    }
}
