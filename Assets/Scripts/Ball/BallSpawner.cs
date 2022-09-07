using UnityEngine;

namespace GDT.Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnOffset = 1.5f;
        [SerializeField] private Ball ballPrefab;

        private void Start()
        {
            SpawnBalls(BallIndexer.IndexesArray);
        }

        public void SpawnBalls(int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.z += i * spawnOffset;

                Ball ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity, transform);
                ball.Setup(indexes[i]);
            }
        }
    }
}