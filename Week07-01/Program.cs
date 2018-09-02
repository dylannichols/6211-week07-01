using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Week07_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = "C:\\Moisture_Data.txt";
            double[] data = ImportData(location);

            Console.WriteLine($"The maximum value is: {FindMaxLinear(data)}");
            Console.WriteLine($"The minimum value is: {FindMinLinear(data)}");
            double average = Math.Round(FindAverageLinear(data), 2);
            Console.WriteLine($"The average value is: {average}");

            Stopwatch sw = new Stopwatch();

            double[] bubbleSortArray = new double[data.Length];
            data.CopyTo(bubbleSortArray, 0);
            sw.Start();
            BubbleSort(bubbleSortArray);
            sw.Stop();
            Console.WriteLine($"Bubble Sort took {sw.Elapsed}");
            sw.Reset();

            double[] insertionSortArray = new double[data.Length];
            data.CopyTo(insertionSortArray, 0);
            sw.Start();
            InsertionSort(insertionSortArray);
            sw.Stop();
            Console.WriteLine($"Insertion Sort took {sw.Elapsed}");
            sw.Reset();

            double[] selectionSortArray = new double[data.Length];
            data.CopyTo(selectionSortArray, 0);
            sw.Start();
            SelectionSort(selectionSortArray);
            sw.Stop();
            Console.WriteLine($"Selection Sort took {sw.Elapsed}");
            sw.Reset();

            bool containsAverage = false;
            sw.Start();
            for (int i = 0; i < selectionSortArray.Length; i++)
            {
                if (selectionSortArray[i] == average)
                    containsAverage = true;
            }
            sw.Stop();
            if (containsAverage)
                Console.WriteLine($"Found average in {sw.Elapsed}");

            sw.Reset();

            sw.Start();
            containsAverage = BinarySearch(selectionSortArray, average, 0, selectionSortArray.Length);
            sw.Stop();
            if (containsAverage)
                Console.WriteLine($"Found average with binary search in {sw.Elapsed}");




            Console.ReadKey();
        }

        public static bool BinarySearch(double[] arr, double toFind, int min, int max)
        {
            if (min > max)
                return false;

            int mid = (min + max) / 2;

            if (toFind == arr[mid])
                return true;
            else if (toFind < arr[mid])
                return BinarySearch(arr, toFind, min, mid - 1);
            else
                return BinarySearch(arr, toFind, mid + 1, max);
        }

        public static void SelectionSort(double[] arr)
        {
            int min;
            double temp;
            for (int i = 0; i < arr.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        public static void InsertionSort(double[] arr)
        {
            double temp = 0;
            for (int i = 0; i < arr.Length- 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--;
                }
            }
        }

        public static void BubbleSort(double[] arr)
        {
            double temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static double FindMaxLinear(double[] arr)
        {
            double max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public static double FindMinLinear(double[] arr)
        {
            double min = 100;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public static double FindAverageLinear(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }

        public static double[] ImportData(string location)
        {
            string[] tempArray = File.ReadLines(location).ToArray();
            double[] newArray = new double[tempArray.Length];
            for (int i = 0; i < tempArray.Length; i++)
            {
                newArray[i] = double.Parse(tempArray[i]);
            }
            return newArray;
        }
    }
}
