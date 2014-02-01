/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package helloworld;

import java.util.*;


/**
 *
 * @author ashab
 */
public class PartitionLinkedList {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        System.out.println("Hello world");
        
        LinkedListNode head = new LinkedListNode(8);

        LinkedListNode node1 = new LinkedListNode(5);
        LinkedListNode node2 = new LinkedListNode(2);
        LinkedListNode node3 = new LinkedListNode(6);
        LinkedListNode node4 = new LinkedListNode(3);
        
        head.Next = node1;
        node1.Next = node2;
        node2.Next = node3;
        node3.Next = node4;
        
        Partition(head, 5);        
    }
   
    public static void Partition(LinkedListNode node, int x)
    {
        LinkedListNode beforeStart = null;
        LinkedListNode beforeEnd = null;
        
        LinkedListNode afterStart = null;
        LinkedListNode afterEnd = null;
        
        while (node != null)
        {
            LinkedListNode next = node.Next;
            node.Next = null;
            
            if (node.Data < x)
            {
               if (beforeStart == null)
               {
                   beforeStart = node;
                   beforeEnd = node;
               }
               else
               {
                   beforeEnd.Next = node;
                   beforeEnd = node;
               }
            }
            else
            {
                if (afterStart == null)
                {
                    afterStart = node;
                    afterEnd = node;
                } 
                else
                {
                    afterEnd.Next = node;
                    afterEnd = node;
                }
            }            
            
            node = next;
        }
        
        if (beforeStart == null)
        {
            beforeStart = afterStart;
        }
        else
        {
            LinkedListNode current = beforeStart;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = afterStart;
        }
        
        System.out.println("Partitioned list is");
        
        LinkedListNode print = beforeStart;
        
        while (print != null)
        {
            System.out.print(print.Data + " ");
            print = print.Next;
        }
    }
}

