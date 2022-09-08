using System;
using System.Collections;
using UnityEngine;

namespace GDT.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float smoothDampSpeed = 100f;
        [SerializeField] private int smoothDampRound = 4;

        private Vector3 velocity = Vector3.zero;

        public IEnumerator MoveTo(Vector3 targetPosition)
        {
            while (Math.Round(transform.position.z, smoothDampRound) != Math.Round(targetPosition.z, smoothDampRound))
            {
                Debug.Log("Rusza sie");
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, Time.deltaTime / smoothDampSpeed);
                yield return null;
            }
        }
    }
}