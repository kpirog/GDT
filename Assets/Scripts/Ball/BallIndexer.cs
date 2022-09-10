using UnityEngine;
using GDT.Core;

namespace GDT.BallSpace
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
            GenerateRandomIndexes();
        }

        private void OnEnable()
        {
            EventManager.onMenuOpenedEvent += GenerateRandomIndexes;
            EventManager.onGameRestartedEvent += GenerateRandomIndexes; 
        }

        private void OnDisable()
        {
            EventManager.onMenuOpenedEvent += GenerateRandomIndexes;
            EventManager.onGameRestartedEvent += GenerateRandomIndexes;
        }

        private void GenerateRandomIndexes()
        {
            indexesArray = new int[elementsCount];
            indexesArray.FillArrayRandomly(rangeOfNumbers);
        }
    }
}