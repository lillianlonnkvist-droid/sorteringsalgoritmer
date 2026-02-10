using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ConsoleApp1
{
    internal class Program
    {
        static int numSwaps = 0;
        static void Main(string[] args)
        {
            #region test
            Stopwatch timer = new Stopwatch();
            Random rng = new Random();
            #endregion
            int[] unsortedList = { 3, 6, 2 }; //new int[10000];
            /* for (int i = 0; i < unsortedList.Length; i++)
             {
                 unsortedList[i] = rng.Next(999);
             }*/
            Console.WriteLine("Detta är den osorterade listan");
            PrintArray(unsortedList);
            timer.Start();
            int[] sortedList = SelectionSort(unsortedList);
            timer.Stop();

            Console.WriteLine($"\n\nDet tog {timer.Elapsed.TotalSeconds} att sortera. Resultatet är:");
            Console.WriteLine($"Vi har gjort {numSwaps} byten");
            PrintArray(sortedList);

            Console.ReadKey();
        }

        static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            numSwaps += 1;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
                if (i % 20 == 0 && i != 0)
                {
                    Console.Write("\n");
                }

            }
        }

        static int[] UselessSort(int[] unsorted)
        {
            Swap(unsorted, 0, 1);
            System.Threading.Thread.Sleep(1000);//paus i 1 sekund
            return unsorted;
        }

        static int[] BogoSort(int[] unsorted)
        {
            while (IsSorted(unsorted) == false)
            {
                unsorted = Shuffle(unsorted);
            }
            return unsorted;
        }

        static int[] Shuffle(int[] array)
        {
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, i, rng.Next(0, array.Length));
            }
            return array;
        }

        static bool IsSorted(int[] array)
        {
            for (int x = 0; x < array.Length - 1; x++)
            {
                if (array[x] > array[x + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static int[] BubbleSort(int[] unsorted)
        {
            bool hasSwitched = true;
            while (hasSwitched == true)
            {
                hasSwitched = false;
                for (int x = 0; x < unsorted.Length - 1; x++)
                {
                    if (unsorted[x] > unsorted[x + 1])
                    {
                        Swap(unsorted, x, x + 1);
                        hasSwitched = true;
                    }
                }
            }
            return unsorted;
        }

        static int[] SelectionSort(int[] unsorted)
        {
            int smallestValue = 1000000; //minsta värdet i listan
            int smallestIndex = 0; //platsen i listan för det minsta värdet
            for (int x = 0; x < unsorted.Length; x++)
            {
                for (int i = x; i < unsorted.Length; i++)
                {
                    if (unsorted[i] < smallestValue)
                    {
                        smallestValue = unsorted[i];
                        smallestIndex = i;
                    }
                }
                Swap(unsorted, x, smallestIndex);
                smallestValue = 1000000;
            }
            return unsorted;
        }
    }
}
