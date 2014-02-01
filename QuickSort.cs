using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 16, 4, 11, 21, 7, -3, 44 };

            quickSort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted array is");

            foreach (int value in array)
            {
                Console.WriteLine(value);
            }
        }

        static void quickSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int index = partition(input, left, right);

                quickSort(input, left, index - 1);

                quickSort(input, index, right);
            }
        }

        static int partition(int[] input, int left, int right)
        {
            int pivotIndex = (left + right)/2;

            int pivot = input[pivotIndex];

            while (left <= right)
            {
                while (input[left] < pivot)
                {
                    left++;
                }

                while (input[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    swap(ref input[left], ref input[right]);
                    left++;
                    right--;
                }
            }

            return left;
        }

        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }
    }
}
