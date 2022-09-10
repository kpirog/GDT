using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace GDT.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private float moveAnimationTime = 1f;

        private int pickupKey = Animator.StringToHash("PickUp");
        private int idleKey = Animator.StringToHash("Idle");
        
        private bool animationFinished;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        public IEnumerator MoveTo(float zAxis)
        {
            yield return transform
                .DOMoveZ(zAxis, moveAnimationTime)
                .WaitForCompletion();
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
        public void FinishAnimation() //animation Event
        {
            animationFinished = true;
        }
        public void ResetAnimator()
        {
            anim.Play(idleKey);
        }
    }
}