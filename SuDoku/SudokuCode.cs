using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuDoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,]{ 
                                        {1, 2, 4, 3}, 
                                        {4, 3, 1, 2}, 
                                        {3, 1, 2, 4}, 
                                        {2, 4, 3, 1}, 
                                       };

            // int row = 3;
            // int column = 1;
            int n = 4;
            // int num = 3;
            int regionSize = 2;

            // bool result = checkValid(board, row, column, num, n, regionSize);

            bool result = IsValid(board, n, regionSize);

            Console.WriteLine("Result is {0}", result);
        }


        static bool IsValid (int[,] board, int n, int regionSize)
        {
           // Check all rows
   
           for(int i = 0; i < n; i++)
           {
               HashSet<int> rowValues = new HashSet<int>();

               for(int j = 0; j < n; j++)
               {
                  if (rowValues.Add(board[i,j]) == false)
                  {
                     return false;
                  }
               }
           }

           // Check all columns

           for (int j = 0; j < n; j++)
           {
               HashSet<int> columnValues = new HashSet<int>();

               for(int i = 0; i < n; i++)
               {
                  if (columnValues.Add(board[i, j]) == false)
                  {
                     return false; 
                  }
               }
           }

           // Check all blocks

           for (int i = 0; i < n; i += regionSize)
           {
               for (int j = 0; j < n; j += regionSize)
              {
                   HashSet<int> blockValues = new HashSet<int>();

                   for (int k = i; k < i + regionSize; k++)
                   {
                       for (int l = j; l < j + regionSize; l++)
                       {
                           if (blockValues.Add(board[k, l]) == false)
                           {
                               return false; 
                           }
                       }
                   }
              }
           }

           return true;    
        }


        // assuming board cells can have values between 1-9 and empty
        // cells have a 0
        static bool checkValid(int[,] board, int row, int column, int num, int n, int regionSize)
        {
            HashSet<int> rowValues = new HashSet<int>();

            for(int i = 0; i < n; i++)
            {
                if (board[row, i] != 0)
                {
                   rowValues.Add(board[row, i]);
                }
            }

            bool numberPresentInRow = rowValues.Contains(num);

            if (numberPresentInRow)
            {
                return false;   
            }

            HashSet<int> columnValues = new HashSet<int>();

            for(int j = 0; j < n; j++)
            {
               if (board[j, column] != 0)
               {
                   columnValues.Add(board[j, column]);
               }
            }   

            bool numberPresentInColumn = columnValues.Contains(num);

            if (numberPresentInColumn)
            {
                 return false;
            }

            // Now check the 3 x 3 square surrounding this cell
            int blockRowStart = 0;
            int blockColumnStart = 0;
            GetRegion(row, column, ref blockRowStart, ref blockColumnStart, regionSize);

            HashSet<int> threeByThreeBlockSet = new HashSet<int>();

            for(int i = blockRowStart; i < 3; i++)
            {
               for(int j = blockColumnStart; j < 3; j++)
               {
                   threeByThreeBlockSet.Add(board[i, j]);
               }
            }

            bool IsNumberPresentInThreeByThreeBlock = threeByThreeBlockSet.Contains(num);

            return !IsNumberPresentInThreeByThreeBlock;   
        }


        static void GetRegion(int currentRow, int currentCol, ref int blockRowStart, ref int blockColumnStart, int regionSize)
        {
            int blockRow = currentRow / regionSize;

            int blockColumn = currentCol / regionSize;

            blockRowStart = blockRow * regionSize;
            blockColumn = blockColumn * regionSize;
        }
    }
}
