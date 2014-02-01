using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInSorted2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 4] { { 1, 4, 5, 20 }, { 2, 8, 11, 22}, { 3, 9, 14, 25} };

            int rowLength = 3;
            int columnLength = 4;

            Console.WriteLine("Result : {0}", Find(matrix, rowLength, columnLength, 25));
        }

        static bool Find(int[,] matrix, int rowLength, int columnLength, int value)
        {
            int currentRow = 0;
            int currentColumn = columnLength - 1;

            while (currentRow >=0 && currentRow < rowLength &&
                   currentColumn >=0 && currentColumn < columnLength)
            {
                 if (value == matrix[currentRow, currentColumn])
                 {
                     return true;
                 }
                 else if (value < matrix[currentRow, currentColumn])
                 {
                     currentColumn--;
                 }
                 else
                 {
                     currentRow++;
                 }
            }

            return false;
        }

    }
}
