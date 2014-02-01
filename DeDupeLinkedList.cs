using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deleteDupsLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(2);
            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(7);
            list.AddLast(7);
            list.AddLast(2);
            list.AddLast(8);

            Console.WriteLine("Original list");

            LinkedList<int>.Enumerator enumerator1 = list.GetEnumerator();

            while (enumerator1.MoveNext())
            {
                Console.WriteLine(enumerator1.Current);
            }
            
            deleteDups3(list);

            Console.WriteLine("Deduped list");

            LinkedList<int>.Enumerator enumerator2 = list.GetEnumerator();

            while (enumerator2.MoveNext())
            {
                Console.WriteLine(enumerator2.Current);
            }

        }

        // Remove duplicates from an unsorted linked list

        // O(n) time and O(n) space
        static void deleteDups(LinkedList<int> n)
        {
            HashSet<int> hashSet = new HashSet<int>();

            LinkedListNode<int> current = n.First;

            while (current != null)
            {
                if (hashSet.Contains(current.Value))
                {
                    LinkedListNode<int> nextNode = current.Next;
                    n.Remove(current);
                    current = nextNode;
                }
                else
                {
                    hashSet.Add(current.Value);
                    current = current.Next;
                }
            }
        }

        // O(n * n) time and O(1) space
        static void deleteDups2(LinkedList<int> n)
        {
            LinkedListNode<int> current = n.First;

            while (current != null)
            {
                LinkedListNode<int> runner = current.Next;

                while (runner != null)
                {
                    if (runner.Value == current.Value)
                    {
                        n.Remove(runner);
                    }

                    runner = runner.Next;
                }

                current = current.Next;
            }
        }

        // O(nlogn) time and O(1) space
        static void deleteDups3(LinkedList<int> n)
        {
            // Sort the list
            var sortedList = n.OrderBy(i => i);

            List<int> tempList = sortedList.ToList();

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                if (tempList[i] == tempList[i + 1])
                {
                    n.Remove(tempList[i]);
                }
            }            
        }
    }
}
