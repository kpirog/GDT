using GDT.Elements;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace GDT.Character
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private BallSorter ballSorter;
        [SerializeField] private bool isSorting = false;

        [SerializeField] private Transform rightHandSlot;
        [SerializeField] private Transform leftHandSlot;

        private CharacterAnimation characterAnimation;

        private int currentBallIndex = 0;
        private bool hasBall = false;

        private void Awake()
        {
            characterAnimation = GetComponent<CharacterAnimation>();;
        }
        private void Update()
        {
            if (CanSort() && isSorting)
            {
                StartCoroutine(DoSort());
                isSorting = false;
            }
        }
        private IEnumerator DoSort()
        {
            Ball firstBall = ballSorter.Balls[currentBallIndex];

            if (!hasBall)
            {
                yield return StartCoroutine(MoveTo(firstBall.transform.position.z));
                yield return StartCoroutine(PickupBall(firstBall, true));
            }

            Ball secondBall = GetBallOnDesiredPosition(firstBall);

            if (secondBall != null)
            {
                yield return StartCoroutine(MoveTo(secondBall.transform.position.z));
                yield return StartCoroutine(PickupBall(secondBall, false));
                yield return StartCoroutine(PutDownBall(firstBall));
                hasBall = true;
                currentBallIndex = ballSorter.Balls.IndexOf(secondBall);
                secondBall.transform.SetParent(rightHandSlot);
            }
            else
            {
                yield return StartCoroutine(MoveTo(firstBall.desiredPos.z));
                yield return StartCoroutine(PutDownBall(firstBall));
                hasBall = false;
                currentBallIndex = GetFirstUnsortedBallIndex();
            }


            isSorting = true;
        }

        private bool CanSort()
        {
            return ballSorter.Balls.Any(x => !x.isSorted);
        }

        private int GetFirstUnsortedBallIndex()
        {
            return ballSorter.Balls.Where(x => !x.isSorted).Select(x => ballSorter.Balls.IndexOf(x)).FirstOrDefault();
        }

        private IEnumerator PutDownBall(Ball ball)
        {
            yield return StartCoroutine(characterAnimation.PickUp());
            ball.transform.SetParent(ballSorter.transform);
            ball.transform.position = ball.desiredPos;
            ball.isSorted = true;
        }

        private IEnumerator PickupBall(Ball ball, bool rightHand)
        {
            yield return StartCoroutine(characterAnimation.PickUp());
            ball.transform.SetParent(rightHand ? rightHandSlot : leftHandSlot);
        }
        private IEnumerator MoveTo(float zAxis)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, zAxis);
            yield return StartCoroutine(characterAnimation.MoveTo(targetPosition));
        }

        private Ball GetBallOnDesiredPosition(Ball firstBall)
        {
            return ballSorter.Balls
                .Where(x => x.transform.position == firstBall.desiredPos && x != firstBall)
                .FirstOrDefault();
        }
    }
}