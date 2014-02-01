using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given two numbers each represented by a linked list,
// where each node contains a single digit. The digits are
// stored in reverse order

// 7 -> 1-> 6
// 5 -> 9 -> 2
// That is 617 + 295 = 912
// 219

namespace SumLinkedList2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> l1 = new LinkedList<int>();
            l1.AddLast(7);
            l1.AddLast(1);
            l1.AddLast(6);

            LinkedList<int> l2 = new LinkedList<int>();
            l2.AddLast(5);
            l2.AddLast(9);
            l2.AddLast(2);

            LinkedList<int> result = sum(l1, l2);

            LinkedListNode<int> node = result.First;

            while (node != null)
            {
                Console.Write(node.Value);
                node = node.Next;
            }

            Console.WriteLine();
        }

        static LinkedList<int> sum(LinkedList<int> l1, LinkedList<int> l2)
        {
            LinkedListNode<int> current1 = l1.First;

            LinkedListNode<int> current2 = l2.First;

            bool IsCarryPresent = false;

            LinkedList<int> result = new LinkedList<int>();

            while (current1 != null && current2 != null)
            {
                int sum = (current1.Value + current2.Value);

                if (IsCarryPresent)
                {
                    sum++;
                }

                result.AddLast(sum % 10);

                if (sum / 10 > 0)
                {
                    IsCarryPresent = true;
                }
                else
                {
                    IsCarryPresent = false;
                }

                current1 = current1.Next;
                current2 = current2.Next;
            }

            if (current1 != null)
            {
                AddRemainingValues(current1, result, IsCarryPresent);
            }
            else if (current2 != null)
            {
                AddRemainingValues(current1, result, IsCarryPresent);
            }
            else 
            {
                if (IsCarryPresent)
                {
                    result.AddLast(1);
                }
            }

            return result;
        }

        static void AddRemainingValues(LinkedListNode<int> node, LinkedList<int> result, bool IsCarryPresent)
        {
            while (node != null)
            {
                int sum = node.Value;

                if (IsCarryPresent)
                {
                    sum++;
                }

                result.AddLast(sum % 10);

                if (sum / 10 > 0)
                {
                    IsCarryPresent = true;
                }
                else
                {
                    IsCarryPresent = false;
                }

                node = node.Next;
            }

            if (IsCarryPresent)
            {
                result.AddLast(1);
            }
        }


    }
}
