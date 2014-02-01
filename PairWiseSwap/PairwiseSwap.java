/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* Given a singly linked list, write a function to swap elements pairwise. 
   For example, if the linked list is 1->2->3->4->5->6->7 then the function should change it 
   to 2->1->4->3->6->5->7, and if the linked list is 1->2->3->4->5->6 then the function should
   change it to 2->1->4->3->6->5 */

package pairwiseswap;

/**
 *
 * @author ashab
 */
public class PairwiseSwap {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        LinkedListNode head = new LinkedListNode(1);

        LinkedListNode node1 = new LinkedListNode(2);
        LinkedListNode node2 = new LinkedListNode(3);
        LinkedListNode node3 = new LinkedListNode(4);
        LinkedListNode node4 = new LinkedListNode(5);
        LinkedListNode node5 = new LinkedListNode(6);
        LinkedListNode node6 = new LinkedListNode(7);
                
        head.Next = node1;
        node1.Next = node2;
        node2.Next = node3;
        node3.Next = node4;
        node4.Next = node5;
        node5.Next = node6;
        
        head = PairWiseSwap2(head);
        
        System.out.println("Result is");
        LinkedListNode print  = head;
        
        while (print != null)
        {
            System.out.print(print.Data + " ");
            print = print.Next;
        }
        
    }
    
    public static void PairWiseSwap(LinkedListNode head)
    {
        LinkedListNode current = head;
        
        LinkedListNode next = null;
        LinkedListNode nodeAfterNext = null;
    
        while (current != null)
        {
            next = current.Next;

            if (next != null)
            {
                nodeAfterNext = next.Next;
                SwapValues(current, next);
            }

           current = nodeAfterNext;
           nodeAfterNext = null;
        }                     
    }
    
    public static LinkedListNode PairWiseSwap2(LinkedListNode head)
    {
        if (head == null || head.Next == null)
        {
            return head;
        }        
        
        LinkedListNode curr;
        LinkedListNode prev;
        LinkedListNode remaining;
        
        prev = head;
        curr = head.Next;
        remaining = head.Next.Next;
        
        curr.Next = prev;
        prev.Next = PairWiseSwap2(remaining);
                
        return curr;
    }
    
    public static void SwapValues(LinkedListNode a, LinkedListNode b)
    {
       int temp = 0;
       temp = a.Data;
       a.Data = b.Data;
       b.Data = temp;
    }
    
}
