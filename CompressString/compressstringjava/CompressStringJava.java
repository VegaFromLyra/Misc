/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package compressstringjava;

/**
 *
 * @author ashab
 */
public class CompressStringJava {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        String input = "aaabb";
        System.out.println("Compressed version of " + input + " is " + Compress(input));
    }
    
    static String Compress(String input)
    {
        int compressedSize = GetCompressedSize(input);
        
        if (compressedSize > input.length())
        {
            return input;
        }
        
        char last = input.charAt(0);
        int count = 1;
        
        StringBuilder sb = new StringBuilder("");
        
        for(int i = 1; i < input.length(); i++)
        {
            if (input.charAt(i) == last)
            {
                count++;
            }
            else
            {
                sb.append(last);
                sb.append(String.valueOf(count));
                last = input.charAt(i);
                count = 1;
            }
        }
        
        // Append the last character and its count
        sb.append(last);
        sb.append(String.valueOf(count));  
        
        return sb.toString();
    }
    
    static int GetCompressedSize(String input)
    {
        if (input == null || input.isEmpty())
        {
            throw new IllegalArgumentException("Invalid input");
        }

        int count = 1;
        int size = 0;
        char last = input.charAt(0);

        for (int i = 1; i < input.length(); i++)
        {
            if (input.charAt(i) == last)
            {
                count++;
            }
            else
            {
                last = input.charAt(i);
                size += 1 + String.valueOf(count).length(); // size = current character + sizeof(count)

                //reset count
                count = 1;
            }
        }

        return size;
    }        
}
