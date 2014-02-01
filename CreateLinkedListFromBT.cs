using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLinkedListFromBinaryTree
{
    class Program
    {
        class Node
        {
            public Node(int data)
            {
                Data = data;
            }

            public int Data { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        static void Main(string[] args)
        {
            Node node = new Node(5);
            node.Left = new Node(6);
            node.Right = new Node(7);

            List<LinkedList<Node>> result = CreateLevelLinkedList2(node);
        }

        static List<LinkedList<Node>> CreateLevelLinkedList1(Node n)
        {
            List<LinkedList<Node>> result = new List<LinkedList<Node>>();

            Queue<Node> parentQueue = new Queue<Node>();
            parentQueue.Enqueue(n);

            Queue<Node> childQueue = new Queue<Node>();

            LinkedList<Node> currentList = new LinkedList<Node>();

            while (parentQueue.Count > 0)
            {
                Node parentNode = parentQueue.Dequeue();

                currentList.AddLast(parentNode);

                if (parentNode.Left != null)
                {
                    childQueue.Enqueue(parentNode.Left);
                }

                if (parentNode.Right != null)
                {
                    childQueue.Enqueue(parentNode.Right);
                }

                if (parentQueue.Count == 0)
                {
                    result.Add(currentList);
                    parentQueue = childQueue;
                    childQueue = new Queue<Node>();
                    currentList = new LinkedList<Node>();
                }
            }

            return result;
        }

        static List<LinkedList<Node>> CreateLevelLinkedList2(Node n)
        {
            List<LinkedList<Node>> result = new List<LinkedList<Node>>();

            LinkedList<Node> current = new LinkedList<Node>();

            if (n != null)
            {
                current.AddLast(n);
            }

            while (current.Count > 0)
            {
                result.Add(current);
                LinkedList<Node> parents = current;
                current = new LinkedList<Node>();

                foreach (Node parent in parents)
                {
                    if (parent.Left != null)
                    {
                        current.AddLast(parent.Left);
                    }

                    if (parent.Right != null)
                    {
                        current.AddLast(parent.Right);
                    }
                }
            }

            return result;
        }
    }
}
