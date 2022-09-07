using System;

namespace GDT.Algorithms
{
    public interface IAlgorithm
    {
        void Execute(Action<int, int> Swap, int[] indexes);
    }
}