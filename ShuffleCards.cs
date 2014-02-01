using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Write a program for deck shuffling. And make sure that no card will get the same position as previously. 
//i.e. after shuffle all card should have different position.

namespace ShuffleDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 52;

            int[] deck = new int[number];

            for (int i = 0; i < number; i++)
            {
                deck[i] = i + 1;
            }

            ShuffleDeck(deck);

            Console.WriteLine("Shuffled card IDs are");

            for (int i = 0; i < deck.Length; i++)
            {
                Console.Write(deck[i] + " ");
            }
        }

        static void ShuffleDeck(int[] deck)
        {
            Dictionary<int, HashSet<int>> table = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < deck.Length; i++)
            {
                HashSet<int> set = new HashSet<int>();
                set.Add(i);
                table.Add(deck[i], set);
            }

            for (int i = 0; i < deck.Length; i++)
            {

                int random = new Random().Next(deck.Length - 1);

                while (table[deck[i]].Contains(random))
                {
                    random = new Random().Next(deck.Length - 1);
                }

                int temp = deck[random];
                deck[random] = deck[i];
                deck[i] = temp;

                table[deck[i]].Add(random);
            }
        }
    }
}
