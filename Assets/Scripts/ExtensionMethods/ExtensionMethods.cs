using UnityEngine;

namespace GDT.Extensions
{
    public static class ExtensionMethods
    {
        public static void FillArrayRandomly(this int[] array, int count, int range)
        {
            array = new int[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Range(1, range);
            }
        }
    }
}