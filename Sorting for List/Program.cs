using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sorting_for_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int>();

            const int COUNT = 1000000;
            Stopwatch watch = Stopwatch.StartNew();


            AddList(numberList);

            Console.WriteLine("\n Before List.Sort");

            foreach (var item in numberList)
            {
                Console.Write($" {item} ");
            }


            Console.WriteLine("\n\n After List.Sort (works on the principle of Quick Sort)");
            for (int i = 0; i < COUNT; i++)
            {
                numberList.Sort();
            }

            foreach (var item in numberList)
            {

                Console.Write($" {item} ");
            }

            watch.Stop();
            Console.WriteLine("\n => List.Sort: {0}ms", watch.ElapsedMilliseconds);



            numberList.Clear();



            Console.WriteLine("\n\n Before Bubble Sort ");

            AddList(numberList);

            foreach (var item in numberList)
            {

                Console.Write($" {item} ");
            }


            Console.WriteLine("\n\n After Bubble Sort ");

            BubbleSort(numberList);


            foreach (var item in numberList)
            {

                Console.Write($" {item} ");
            }

            watch.Stop();
            Console.WriteLine("\n => Bubble Sort: {0}ms", watch.ElapsedMilliseconds);



            numberList.Clear();



            Console.WriteLine("\n\n Before Merge Sort ");

            AddList(numberList);

            foreach (var item in numberList)
            {

                Console.Write($" {item} ");
            }


            Console.WriteLine("\n\n After Merge Sort ");

            List<int> sorted;

            sorted = MergeSort(numberList);

            foreach (var item in sorted)
            {

                Console.Write($" {item} ");
            }

            watch.Stop();
            Console.WriteLine("\n => Merge Sort: {0}ms", watch.ElapsedMilliseconds);



            numberList.Clear();



            Console.WriteLine("\n\n Before Insertion Sort ");

            AddList(numberList);

            foreach (var item in numberList)
            {

                Console.Write($" {item} ");
            }


            Console.WriteLine("\n\n After Insertion Sort ");

            var listArray = numberList.ToArray();

            InsertionSort(listArray);

            var list = listArray.ToList();

            foreach (var item in list)
            {

                Console.Write($" {item} ");
            }

            watch.Stop();
            Console.WriteLine("\n => Insertion Sort: {0}ms", watch.ElapsedMilliseconds);


            Console.WriteLine();

        }








        static void AddList(List<int> numberList)
        {
            numberList.Add(1);
            numberList.Add(5341);
            numberList.Add(0);
            numberList.Add(12);
            numberList.Add(22);
            numberList.Add(51);
            numberList.Add(155);
            numberList.Add(10);
            numberList.Add(18);
            numberList.Add(81);
            numberList.Add(10);
            numberList.Add(23432);
            numberList.Add(1);
            numberList.Add(32);
            numberList.Add(78);
            numberList.Add(12);
            numberList.Add(155);
            numberList.Add(2234);
            numberList.Add(8);
            numberList.Add(41);
            numberList.Add(19);
            numberList.Add(67);
            numberList.Add(23);
            numberList.Add(242);
            numberList.Add(234);
        }


        static void BubbleSort(List<int> numberList)
        {
            int len = numberList.Count;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    int a = numberList[j];
                    if (a != numberList[len - 1])
                    {
                        int b = numberList[j + 1];
                        if (a > b)
                        {
                            numberList[j] = b;
                            numberList[j + 1] = a;
                        }
                    }
                }
            }
        }


        static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
        

        static void InsertionSort(int[] listArray)
        {

            int n = listArray.Length;
            for (int i = 1; i < n; ++i)
            {
                var key = listArray[i];
                var j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && listArray[j] > key)
                {
                    listArray[j + 1] = listArray[j];
                    j = j - 1;
                }
                listArray[j + 1] = key;
            }
        }

    }



}





