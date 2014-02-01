using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraverseZigZag
{
    class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data;

        public Node Left;

        public Node Right;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(2);
            node.Left = new Node(3);
            node.Right = new Node(4);

            node.Left.Left = new Node(5);
            node.Left.Right = new Node(6);

            TraverseZigZag(node);
        }


        static void TraverseZigZag(Node n)
        {
            Stack<Node> parentStack = new Stack<Node>();
            Stack<Node> childrenStack = new Stack<Node>();
            bool addChildrenLeftToRight = true;

            if (n != null)
            {
                parentStack.Push(n);
            }

            while (parentStack.Count > 0)
            {
                Node node = parentStack.Pop();

                Console.Write(node.Data + " ");

                if (addChildrenLeftToRight)
                {
                    if (node.Left != null)
                    {
                        childrenStack.Push(node.Left);
                    }

                    if (node.Right != null)
                    {
                        childrenStack.Push(node.Right);
                    }

                }
                else
                {
                    if (node.Right != null)
                    {
                        childrenStack.Push(node.Right);
                    }

                    if (node.Left != null)
                    {
                        childrenStack.Push(node.Left);
                    }

                }

                if (parentStack.Count == 0)
                {
                    addChildrenLeftToRight = !addChildrenLeftToRight;
                    parentStack = childrenStack;
                    childrenStack = new Stack<Node>();
                }
            }
        }

    }
}
