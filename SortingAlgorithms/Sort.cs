using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class Sort
    {
        public static void SelectionSort(int[] arr) => SelectionSort(arr, 0);

        private static void SelectionSort(int[] arr, int start)
        {
            int iMin = start;

            for (int i = start + 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[iMin])
                {
                    iMin = i;
                }
            }

            Swap(arr, start, iMin);

            if (++start < arr.Length)
                SelectionSort(arr, start);
        }

        public static void BubbleSort(int[] arr) => BubbleSort(arr, arr.Length);

        private static void BubbleSort(int[] arr, int end)
        {
            for (int i = 1; i < end; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    Swap(arr, i - 1, i);
                }
            }

            if (--end > 1)
                BubbleSort(arr, end);
        }

        public static void QuickSort(int[] arr) => QuickSort(arr, 0, arr.Length);
        
        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = arr[start];

            int j = start;

            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, i, ++j);
                }
            }

            Swap(arr, start, j);

            QuickSort(arr, start, j);
            QuickSort(arr, j + 1, end);
        }

        public static void MergeSort(ref int[] arr) => arr = GetMergeSorted(arr);

        private static int[] GetMergeSorted(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int aLength = arr.Length / 2;
            int bLength = arr.Length % 2 == 1 
                ? arr.Length / 2 + 1 
                : arr.Length / 2;

            int[] a = new int[aLength];
            int[] b = new int[bLength];

            for (int i = 0; i < aLength; i++)
            {
                a[i] = arr[i];
            }

            for (int i = aLength; i < arr.Length; i++)
            {
                b[i - aLength] = arr[i];
            }

            a = GetMergeSorted(a);
            b = GetMergeSorted(b);

            return GetMerged(a, b);
        }

        private static int[] GetMerged(int[] a, int[] b)
        {
            int[] merged = new int[a.Length + b.Length];

            int i = 0;

            int iA = 0;
            int iB = 0;

            while (iA < a.Length && iB < b.Length)
            {
                if (a[iA] < b[iB])
                {
                    merged[i++] = a[iA++];
                }
                else
                {
                    merged[i++] = b[iB++];
                }
            }

            while (iA < a.Length)
            {
                merged[i++] = a[iA++];
            }

            while (iB < b.Length)
            {
                merged[i++] = b[iB++];
            }            

            return merged;
        }

        public static void HeapSort(int[] arr)
        {
            for (int i = arr.Length / 2; i >= 0; i--)
            {
                RepairTop(arr, i, arr.Length);
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                RepairTop(arr, 0, i);
            }
        }

        private static void RepairTop(int[] arr, int index, int end)
        {
            int iLeft = index * 2 + 1;
            int iRight = index * 2 + 2;

            if (iLeft >= end)
            {
                return;
            }

            int iGreaterChild = iLeft;

            if (iRight < end && arr[iRight] > arr[iLeft])
            {
                iGreaterChild = iRight;
            }

            if (arr[index] < arr[iGreaterChild])
            {
                Swap(arr, index, iGreaterChild);
                RepairTop(arr, iGreaterChild, end);
            }
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int d = i; d > 0; d--)
                {
                    if (arr[d] < arr[d - 1])
                    {
                        Swap(arr, d, d - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void Swap(int[] arr, int src, int dst)
        {
            int tmp = arr[src]; 
            arr[src] = arr[dst]; 
            arr[dst] = tmp;
        }
    }
}
