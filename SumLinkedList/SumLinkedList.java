/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*

// Given two numbers each represented by a linked list,
// where each node contains a single digit. The digits are
// stored in reverse order

// 7 -> 1-> 6
// 5 -> 9 -> 2
// That is 617 + 295 = 912
// 219
*/

package sumlinkedlist;

import java.util.LinkedList;
/**
 *
 * @author ashab
 */
public class SumLinkedList {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        LinkedList l1 = new LinkedList();
        l1.addLast(7);
        l1.addLast(1);
        l1.addLast(6);

        LinkedList l2 = new LinkedList();
        l2.addLast(5);
        l2.addLast(9);
        l2.addLast(2);

        LinkedList result = sum(l1, l2);        
     
        for(int i = 0; i < result.size(); i++)
        {
            System.out.print(result.get(i));
        }
    }
    
    public static LinkedList sum(LinkedList l1, LinkedList l2)
    {
        LinkedList result = new LinkedList();
        
        boolean IsCarryPresent = false;
       
        while (!l1.isEmpty() && !l2.isEmpty())
        {
            int sum = ((int)l1.removeFirst() + (int)l2.removeFirst());
            
            if (IsCarryPresent)
            {
                sum++;
            }

            result.addLast(sum % 10);

            if (sum / 10 > 0)
            {
                IsCarryPresent = true;
            }
            else
            {
                IsCarryPresent = false;
            }                        
        }
        
        if (!l1.isEmpty())
        {
            AddRemainingValues(l1, result, IsCarryPresent);
        }
        else if (!l2.isEmpty())
        {
            AddRemainingValues(l2, result, IsCarryPresent);
        }
        else
        {
            if (IsCarryPresent)
            {
                result.addLast(1);
            }
        }
                              
        return result;
    }
    
    static void AddRemainingValues(
                            LinkedList input, 
                            LinkedList output, 
                            boolean IsCarryPresent)
    {
        while (!input.isEmpty())
        {
            int sum = (int)input.removeFirst();

            if (IsCarryPresent)
            {
                sum++;
            }

            output.addLast(sum % 10);

            if (sum / 10 > 0)
            {
                IsCarryPresent = true;
            }
            else
            {
                IsCarryPresent = false;
            }
        }

        if (IsCarryPresent)
        {
            output.addLast(1);
        }        
    }
    
}
