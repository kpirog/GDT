using System;

namespace GDT.Algorithms
{
    public class SelectionAlgorithm : IAlgorithm
    {
        public void Execute(Action<int, int> Swap, int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                for (int j = i + 1; j < indexes.Length; j++)
                {
                    if (indexes[i] >= indexes[j])
                    {
                        Swap(i, j);
                    }
                }
            }
        }
    }
}