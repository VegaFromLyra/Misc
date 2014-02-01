/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package stackjava;

import java.util.EmptyStackException;

/**
 *
 * @author ashab
 */
public class Stack {

    private LinkedListNode top;

    void Push(Object data)
    {
       if (top != null)
       {
           LinkedListNode newNode = new LinkedListNode(data);
           newNode.Next = top;
           top = newNode;
       }
       else
       {
           top = new LinkedListNode(data);
       }
    }

    Object Pop() throws EmptyStackException
    {
       if (top == null)
       {
          throw new EmptyStackException();
       }

       Object result = top.Data;
       top = top.Next; 
       return result;
    }

    Object Peek() throws EmptyStackException
    {
       if (top == null)
       {
          throw new EmptyStackException();
       }

       Object result = top.Data;
       return result;
    }
    
}
