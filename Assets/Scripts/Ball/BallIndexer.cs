using UnityEngine;
using GDT.Extensions;

namespace GDT.Ball
{
    [DefaultExecutionOrder(-1)]
    public class BallIndexer : MonoBehaviour
    {
        [SerializeField] [Range(0, 100)] private int rangeOfNumbers;
        [SerializeField] private int elementsCount;

        private static int[] indexesArray;
        public static int[] IndexesArray => indexesArray;

        private void Awake()
        {
            indexesArray = new int[elementsCount];
            indexesArray.FillArrayRandomly(rangeOfNumbers);
        }
    }
}