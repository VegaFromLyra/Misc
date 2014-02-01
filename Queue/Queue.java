/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package stackjava;

/**
 *
 * @author ashab
 */
public class Queue {
    
    LinkedListNode start;
    LinkedListNode end;
    
    public void Enqueue(Object data)
    {
        if (start == null)
        {
            start = new LinkedListNode(data);
            end = start;
        }
        else
        {        
            end.Next = new LinkedListNode(data);;
            end = end.Next;        
        }
    }
    
    public Object Dequeue()
    {
        if (start != null)
        {
            Object result = start.Data;
            start = start.Next;
            return result;
        }
        
        return null;
    }
    
    public Object Peek()
    {
        if (start != null)
        {
            Object result = start.Data;
            return result;
        }
        
        return null;        
    }
}
