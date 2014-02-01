/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package tictactoenjava;

/**
 *
 * @author ashab
 */

    enum Piece
    {
        Empty,
        O,
        X
    };


public class TicTacToe {
    
        private int N;

        private Piece[][] board;
   
        public TicTacToe(int N)
        {
           this.N = N;
        }
 
        public void Init(Piece[][] board)
        {
           this.board = board;
        }

        public Piece HasWon()
        {
            int row = 0;
            int col = 0;

            // Chek rows
            for(row = 0; row < N; row++)
            {
                 if (board[row][0] != Piece.Empty)
                 {
                     for (col = 0; col < N - 1; col++)
                     {
                         if (board[row][col] != board[row][col+1])
                         {
                             break;
                         }
                     }

                     if (col == N - 1)
                     {
                         return board[row][0];
                     }
                 }
            }

            // Check columns
            for(col = 0; col < N; col++)
            {
                 if (board[0][col] != Piece.Empty)
                 {
                     for(row = 0; row < N - 1; row++)
                     {
                         if (board[row][col] != board[row + 1][col])
                         {
                            break;
                         }
                     }

                     if (row == N - 1)
                     {
                         return board[0][col];
                     }        
                 }
            }

            // Check diagonal 1 (top left to bottom right)
            if (board[0][0] != Piece.Empty)
            {
               for(row = 0; row < N - 1; row++)
               {
                   if (board[row][row] != board[row + 1][row + 1])
                   {
                       break;
                   }
               }

               if (row == N - 1)
               {
                   return board[0][0];
               }          
            }

            // Check diagonal 2 (bottom left to top right)
            if (board[N - 1][0] != Piece.Empty)
            {
               for(row = N - 1, col = 0; row >=1 && col < N - 1; row--, col++)
               {
                   if (board[row][col] != board[row - 1][col + 1])
                   {
                       break;
                   }               
               }

               if (row == 0 && col == N - 1)
               {
                   return board[N - 1][0];
               }    
            }         

            return Piece.Empty;
        }     
}
