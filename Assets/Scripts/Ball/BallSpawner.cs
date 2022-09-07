using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDT.Extensions;

namespace GDT.Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] [Range(0, 100)] private int rangeOfNumbers;
        [SerializeField] private int elementsCount;

        [SerializeField] private Ball ballPrefab;

        [SerializeField] private float spawnOffset = 0.5f;
        //private int[] indexes;

        private void Start()
        {
            //indexes.FillArrayRandomly(elementsCount, rangeOfNumbers);
            SpawnBalls();
        }

        private Ball[] SpawnBalls()
        {
            Ball[] spawnedBalls = new Ball[elementsCount];

            for (int i = 0; i < elementsCount; i++)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.z += i * spawnOffset;

                Ball ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity, transform);
                //ball.Setup(indexes[i]);

                spawnedBalls[i] = ball;

            }

            return spawnedBalls;
        }
    }
}