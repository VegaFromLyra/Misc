using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Push(5);
            stack.Push(4);

            Console.WriteLine((int)stack.Pop());
            Console.WriteLine((int)stack.Pop());
        }
    }

    class Stack
    {
        private LinkedList<Object> list;

        public Stack()
        {
            list = new LinkedList<Object>();
        }


        public void Push(Object data)
        {
            list.AddLast(data);
        }

        public Object Pop()
        {
            if (list.Count == 0)
            {
                throw new Exception("Error: Cannot pop from empty stack");
            }

            LinkedListNode<Object> result = list.Last;
            list.RemoveLast();

            return result.Value;
        }

        public Object Peek()
        {
            if (list.Count == 0)
            {
                throw new Exception("Error: Cannot peek from empty stack");
            }

            return list.Last.Value;
        }
    }
}
