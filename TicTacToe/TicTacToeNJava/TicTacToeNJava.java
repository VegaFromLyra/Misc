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
public class TicTacToeNJava {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
            TicTacToe game = new TicTacToe(4);

            Piece[][] input1 = new Piece[][] {
                                             {Piece.X, Piece.X, Piece.X, Piece.X},
                                             {Piece.O, Piece.X, Piece.O, Piece.O},
                                             {Piece.X, Piece.O, Piece.O, Piece.X},
                                             {Piece.X, Piece.O, Piece.O, Piece.X},
                                          };
            game.Init(input1);
            System.out.format("Test case 1: Winner is %s", game.HasWon());
            System.out.println();


            Piece[][] input2 = new Piece[][] {
                                             {Piece.O, Piece.X, Piece.X, Piece.X},
                                             {Piece.O, Piece.X, Piece.O, Piece.X},
                                             {Piece.O, Piece.O, Piece.X, Piece.X},
                                             {Piece.O, Piece.O, Piece.X, Piece.O}
                                          };
            game.Init(input2);
            System.out.format("Test case 2: Winner is %s", game.HasWon());
            System.out.println();


            Piece[][] input3 = new Piece[][] {
                                             {Piece.X, Piece.O, Piece.X, Piece.O},
                                             {Piece.O, Piece.X, Piece.O, Piece.X},
                                             {Piece.O, Piece.X, Piece.X, Piece.O},
                                             {Piece.O, Piece.O, Piece.X, Piece.X}
                                          };
            game.Init(input3);
            System.out.format("Test case 3: Winner is %s", game.HasWon());
            System.out.println();

            Piece[][] input4 = new Piece[][] {
                                             {Piece.X, Piece.O, Piece.O, Piece.O},
                                             {Piece.X, Piece.O, Piece.O, Piece.X},
                                             {Piece.O, Piece.O, Piece.X, Piece.X},
                                             {Piece.O, Piece.X, Piece.X, Piece.X}
                                          };
            game.Init(input4);
            System.out.format("Test case 4: Winner is %s", game.HasWon());   
            System.out.println();
    }
    
}
