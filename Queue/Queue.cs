using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine((int)queue.Dequeue());
            Console.WriteLine((int)queue.Dequeue());
        }
    }

    class Queue
    {
        LinkedList<Object> list;

        public Queue()
        {
            list = new LinkedList<Object>();
        }

        public void Enqueue(Object data)
        {
            list.AddFirst(data);
        }

        public Object Dequeue()
        {
            LinkedListNode<Object> node = list.First;
            list.RemoveFirst();
            return node.Value;
        }

        public Object Peek()
        {
            LinkedListNode<Object> node = list.First;
            list.RemoveFirst();
            return node.Value;
        }
    }

}
