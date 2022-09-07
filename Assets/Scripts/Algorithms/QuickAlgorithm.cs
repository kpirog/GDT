using System;

namespace GDT.Algorithms
{
    public class QuickAlgorithm : IAlgorithm
    {
        public void Execute(Action<int, int> Swap, int[] indexes)
        {
            QuickSort(indexes, 0, indexes.Length - 1, Swap);
        }
        private void QuickSort(int[] indexes, int left, int right, Action<int, int> Swap)
        {
            int i = left;
            int j = right;
            int pivot = indexes[(left + right) / 2];

            while (i <= j)
            {
                while (indexes[i] < pivot) i++;
                while (indexes[j] > pivot) j--;

                if (i <= j)
                {
                    Swap(i, j);

                    i++;
                    j--;
                }
            }

            if (j > left)
            {
                QuickSort(indexes, left, j, Swap);
            }
            if (i < right)
            {
                QuickSort(indexes, i, right, Swap);
            }
        }
    }
}