using System.Collections;
using UnityEngine;

namespace GDT.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        private int pickupKey = Animator.StringToHash("PickUp");
        private bool animationFinished;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        public IEnumerator PickUp()
        {
            animationFinished = false;
            anim.SetTrigger(pickupKey);

            while (!animationFinished)
            {
                yield return null;
            }
        }
        public void FinishAnimation()
        {
            animationFinished = true;
            Debug.Log("Event");
        }
    }
}