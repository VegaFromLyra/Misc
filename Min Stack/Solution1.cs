using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImpln
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Push(5);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(6);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(3);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(7);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Pop();
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Pop();
            Console.WriteLine("Min is {0}", stack.Min());
        }
    }

    class Stack
    {
        private LinkedList<int> list;

        private LinkedList<int> minList;

        public Stack()
        {
            list = new LinkedList<int>();

            minList = new LinkedList<int>();
        }

        public void Push(int value)
        {
            list.AddLast(value);

            if (minList.Count > 0)
            {
                int minValue = minList.Last.Value;

                if (value <= minValue)
                {
                    minList.AddLast(value);
                }
            }
            else
            {
                minList.AddLast(value);
            }
        }

        public int Pop()
        {
            if (list.Last == null)
            {
                throw new Exception("Pop should not be called when stack is empty");
            }

            int value = list.Last.Value;

            if (value == minList.Last.Value)
            {
                minList.Remove(minList.Last);
            }

            list.Remove(list.Last);

            return value;
        }

        public int Peek()
        {
            if (list.Last == null)
            {
                throw new Exception("Peek should not be called when stack is empty");
            }

            return list.Last.Value;
        }

        public bool IsEmpty()
        {
            return (list.Count == 0);
        }

        public int Min()
        {
            if (minList.Count == 0)
            {
                throw new Exception("Min cannot be called on an empty stack");
            }
            
            return minList.Last.Value;
        }
    }
}
