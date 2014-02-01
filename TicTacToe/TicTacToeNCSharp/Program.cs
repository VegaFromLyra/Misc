using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeN
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe(4);

            Piece[,] input1 = new Piece[,] {
                                             {Piece.X, Piece.X, Piece.X, Piece.X},
                                             {Piece.O, Piece.X, Piece.O, Piece.O},
                                             {Piece.X, Piece.O, Piece.O, Piece.X},
                                             {Piece.X, Piece.O, Piece.O, Piece.X},
                                          };
            game.Init(input1);
            Console.WriteLine("Test case 1: Winner is {0}", game.HasWon());


            Piece[,] input2 = new Piece[,] {
                                             {Piece.O, Piece.X, Piece.X, Piece.X},
                                             {Piece.O, Piece.X, Piece.O, Piece.X},
                                             {Piece.O, Piece.O, Piece.X, Piece.X},
                                             {Piece.O, Piece.O, Piece.X, Piece.O}
                                          };
            game.Init(input2);
            Console.WriteLine("Test case 2: Winner is {0}", game.HasWon());


            Piece[,] input3 = new Piece[,] {
                                             {Piece.X, Piece.O, Piece.X, Piece.O},
                                             {Piece.O, Piece.X, Piece.O, Piece.X},
                                             {Piece.O, Piece.X, Piece.X, Piece.O},
                                             {Piece.O, Piece.O, Piece.X, Piece.X}
                                          };
            game.Init(input3);
            Console.WriteLine("Test case 3: Winner is {0}", game.HasWon());

            Piece[,] input4 = new Piece[,] {
                                             {Piece.X, Piece.O, Piece.O, Piece.O},
                                             {Piece.X, Piece.O, Piece.O, Piece.X},
                                             {Piece.O, Piece.O, Piece.X, Piece.X},
                                             {Piece.O, Piece.X, Piece.X, Piece.X}
                                          };
            game.Init(input4);
            Console.WriteLine("Test case 4: Winner is {0}", game.HasWon());

        }
    }
}
