using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthToLast
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(4);
            list.AddLast(2);
            list.AddLast(6);
            list.AddLast(8);

            int k = 1;

            Console.WriteLine("{0}th element from last is {1}", k, findkthFromLast(list, k)); 
        }

        static int findkthFromLast(LinkedList<int> node, int k)
        {
            LinkedListNode<int> p;
            LinkedListNode<int> q;

            p = node.First;
            q = node.First;

            while (k > 0)
            {
                q = q.Next;
                k--;
            }

            while (q.Next != null)
            {
                p = p.Next;
                q = q.Next;
            }

            return p.Value;
        }
    }
}
