using System.Collections.Generic;
using UnityEngine;
using GDT.Algorithms;

namespace GDT.Ball
{
    public class BallSorter : MonoBehaviour
    {
        private IAlgorithm currentAlgorithm;

        private List<Ball> balls;
        private int[] indexes;

        private void Awake()
        {
            currentAlgorithm = new BubbleAlgorithm();
        }

        private void Start()
        {
            indexes = new int[BallIndexer.IndexesArray.Length];

            for (int i = 0; i < BallIndexer.IndexesArray.Length; i++)
            {
                indexes[i] = BallIndexer.IndexesArray[i];
            }

            balls = new List<Ball>(GetComponentsInChildren<Ball>());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartSorting();
            }
        }
        private void StartSorting()
        {
            currentAlgorithm.Execute(SwapBalls, indexes);
        }

        private void SwapBalls(int indexOne, int indexTwo)
        {
            Ball first = balls[indexOne];
            Vector3 firstPosition = first.GetPosition();
            int firstIndex = indexes[indexOne];

            balls[indexOne].transform.position = balls[indexTwo].GetPosition();
            balls[indexOne] = balls[indexTwo];
            indexes[indexOne] = indexes[indexTwo];

            balls[indexTwo].transform.position = firstPosition;
            balls[indexTwo] = first;
            indexes[indexTwo] = firstIndex;
        }
    }
}
