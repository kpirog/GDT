using System;

namespace GDT.Algorithms
{
    public class BubbleAlgorithm : IAlgorithm
    {
        public void Execute(Action<int, int> Swap, int[] indexes)
        {
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                for (int j = 0; j < indexes.Length - 1; j++)
                {
                    if (indexes[j] > indexes[j + 1])
                    {
                        Swap?.Invoke(j, (j + 1));
                    }
                }
            }
        }
    }
}