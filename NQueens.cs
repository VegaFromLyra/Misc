using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        // Time complexity O (n ^ n)
        static void Main(string[] args)
        {
            SolveNQueens(4);
        }

        static void SolveNQueens(int N)
        {
            int[] columns = new int[N];

            ArrayList results = new ArrayList();

            int row = 0;
            placeQueens(row, columns, N, results);

            // Only print first solution

            if (results.Count > 0)
            {
                int[] result = results[0] as int[];

                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("Row: {0}", i);
                    Console.WriteLine("Column: {0}", result[i]);
                    Console.WriteLine();
                }
            }
        }

        private static void placeQueens(int row, int[] columns, int N, ArrayList results)
        {
            if (row == N)
            {
                results.Add(columns.Clone());
            }
            else
            {
                for (int col = 0; col < N; col++)
                {
                    if(IsValid(columns, row, col))
                    {
                        columns[row] = col;
                        placeQueens(row + 1, columns, N, results);
                    }
                }
            }
        }

        private static bool IsValid(int[] columns, int row1, int col1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int col2 = columns[row2];

                if (col1 == col2)
                {
                    return false;
                }

                int columnDistance = Math.Abs(col2 - col1);

                int rowDistance = row1 - row2;

                if (rowDistance == columnDistance)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
