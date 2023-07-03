using SortingAlgorithms;

namespace TestSortingAlgorithms
{
    [TestClass]
    public class UnitTestAlgorithms
    {
        //Quadratic algorithms

        [TestMethod]
        [DataRow(1_000)]
        [DataRow(10_000)]
        public void TestBubbleSort(int count)
        {
            TestAlgorithm(count, Sort.BubbleSort);
        }        

        [TestMethod]
        [DataRow(1_000)]
        [DataRow(10_000)]
        public void TestSelectionSort(int count)
        {
            TestAlgorithm(count, Sort.SelectionSort);
        }

        [TestMethod]
        [DataRow(1_000)]
        [DataRow(10_000)]
        public void TestInsertionSort(int count)
        {
            TestAlgorithm(count, Sort.InsertionSort);
        }

        //Logarithmic algorithms

        [TestMethod]
        [DataRow(1_000)]
        [DataRow(10_000)]
        [DataRow(100_000)]
        [DataRow(1_000_000)]
        public void TestHeapSort(int count)
        {
            TestAlgorithm(count, Sort.HeapSort);
        }

        [TestMethod]
        [DataRow(1_000)]
        [DataRow(10_000)]
        [DataRow(100_000)]
        [DataRow(1_000_000)]
        public void TestQuickSort(int count)
        {
            TestAlgorithm(count, Sort.QuickSort);
        }

        [TestMethod]
        [DataRow(1_000)]
        [DataRow(10_000)]
        [DataRow(100_000)]
        [DataRow(1_000_000)]
        public void TestMergeSort(int count)
        {
            int[] arr = GetRandomArray(count);

            Sort.MergeSort(ref arr);

            Assert.IsTrue(IsSorted(arr));
        }

        public void TestAlgorithm(int count, Action<int[]> func)
        {
            int[] arr = GetRandomArray(count);

            func(arr);

            Assert.IsTrue(IsSorted(arr));
        }

        private int[] GetRandomArray(int count)
        {
            var rng = new Random();

            var result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = rng.Next(-count, count);
            }

            return result;
        }

        private bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}