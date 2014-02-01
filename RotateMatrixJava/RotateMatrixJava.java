/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package rotatematrixjava;

/**
 *
 * @author ashab
 */
public class RotateMatrixJava {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        int[][] input = {
                           {1, 2},
                           {3, 4},
                           {5, 6}

                       };
        
        int rowSize = 3;
        int colSize = 2;
        
        int[][] output = RotateMatrix(input, rowSize, colSize);
        
        for (int i = 0; i < colSize; i++)
        {
            for (int j = 0; j < rowSize; j++)
            {
                System.out.print(output[i][j] + " ");
            }

            System.out.println();
        }
        
        int[][] image = {
                          {1, 2, 3, 4}, 
                          {5, 6, 7, 8}, 
                          {9, 10, 11, 12}, 
                          {13, 14, 15, 16}
                        };
        
        int N = 4;
        
        RotateNxNImage(image, N);
        
        System.out.println("Rotated image is");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                System.out.print(image[i][j] + " ");
            }

            System.out.println();
        }        
        
    }
    
    static int[][] RotateMatrix(int[][] input, int rowSize, int colSize)
    {
        int[][] result = new int[colSize][rowSize];

        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < colSize; j++)
            {
                // Copy ith row from input to (rowSize - 1 - i) column in result
                result[j][rowSize - 1 - i] = input[i][j];
            }
        }

        return result;
    }
    
    // Rotate the N X N matrix by moving one
    // number at a time following the sequence
    // below
    // 1. Save left top number
    // 2. Copy bottom left to top left
    // 3. Copy bottom right to bottom left
    // 4. Copy top right to bottom right
    // 5. Copy top left to top right
    static void RotateNxNImage(int[][] image, int N)
    {
        int start = 0;
        int end = N - 1;
        
        while (start < end)
        {
            for(int i = start; i < end; i++)
            {
                int top = image[start][i];
                int offset = i - start;
                
                // Copy bottom left to top left
                image[start][i] = image[end - offset][start];
                
                // Copy bottom right to bottom left
                image[end - offset][start] = image[end][end - offset];
                
                // Copy top right to bottom right
                image[end][end - offset] = image[i][end];
                
                // Copy top to top right
                image[i][end] = top;
            }
            
            start++;
            end--;
        }
    }
    
    
}
