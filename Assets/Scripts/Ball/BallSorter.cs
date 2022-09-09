using System.Collections.Generic;
using UnityEngine;
using GDT.Algorithms;

namespace GDT.Elements
{
    public class BallSorter : MonoBehaviour
    {
        private IAlgorithm currentAlgorithm;

        private List<Ball> balls;
        private int[] indexes;

        public List<Ball> Balls => balls;

        private void Start()
        {
            indexes = new int[BallIndexer.IndexesArray.Length];

            for (int i = 0; i < BallIndexer.IndexesArray.Length; i++)
            {
                indexes[i] = BallIndexer.IndexesArray[i];
            }

            balls = new List<Ball>(GetComponentsInChildren<Ball>());

            EventManager.onGameStartedEvent += StartSorting;
        }

        private void OnDisable()
        {
            EventManager.onGameStartedEvent -= StartSorting;
        }

        private void StartSorting()        
        {
            currentAlgorithm.Execute(SwapBalls, indexes);
            SetDesiredPositions();
        }

        private void SwapBalls(int indexOne, int indexTwo)
        {
            Ball first = balls[indexOne];
            int firstIndex = indexes[indexOne];

            balls[indexOne] = balls[indexTwo];
            indexes[indexOne] = indexes[indexTwo];

            balls[indexTwo] = first;
            indexes[indexTwo] = firstIndex;
        }
        private void SetDesiredPositions()
        {
            foreach (Ball ball in balls)
            {
                ball.desiredPos = new Vector3(ball.transform.position.x, ball.transform.position.y, (float)balls.IndexOf(ball));

                if (ball.transform.position == ball.desiredPos)
                {
                    ball.isSorted = true;
                    Debug.Log("jest posortowany juz");
                }
            }
        }
        public void SetAlgorithm(AlgorithmType type)
        {
            switch (type)
            {
                default:
                case AlgorithmType.Bubble:
                    currentAlgorithm = new BubbleAlgorithm();
                    break;
                case AlgorithmType.Selection:
                    currentAlgorithm =  new SelectionAlgorithm();
                    break;
                case AlgorithmType.Quick:
                    currentAlgorithm = new QuickAlgorithm();
                    break;
            }
        }
    }
}
