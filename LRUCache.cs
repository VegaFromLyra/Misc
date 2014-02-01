using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(3);

            // 3 - 2 - 1
            // 4 - 3 - 2
            // 2 - 4 - 3
            // 4 - 2 - 3
            // 3 - 4 - 2
            // 6 - 5 - 3


            cache.Add(1);
            cache.Add(2);
            cache.Add(3);
            cache.Add(4);

            cache.AccessValue(2);
            cache.AccessValue(4);
            cache.AccessValue(3);

            Console.WriteLine("Least recently used: Expected {0}, Actual {1}", 2, cache.GetLeastRecentlyUsed());

            cache.Add(5);
            cache.Add(6);

            Console.WriteLine("Least recently used: Expected {0}, Actual {1}", 3, cache.GetLeastRecentlyUsed());
        }
    }
}
