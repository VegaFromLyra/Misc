using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImpln2
{
    class Program
    {
        static void Main(string[] args)
        {
            StackWithMin stack = new StackWithMin();

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

    class StackWithMin
    {
        private Stack<NodeWithMin> stack = new Stack<NodeWithMin>();

        public void Push(int value)
        {
            int newMin = Math.Min(value, Min());

            NodeWithMin newNode = new NodeWithMin();
            newNode.value = value;
            newNode.min = newMin;
            stack.Push(newNode);
        }

        public int Min()
        {
            if (stack.Count == 0)
            {
                return Int32.MaxValue;
            }
            else
            {
                return stack.Peek().min;
            }
        }

        public int Pop()
        {
            return stack.Pop().value;
        }

    }

    class NodeWithMin
    {
        public int value { get; set; }

        public int min { get; set; }
    }
}
