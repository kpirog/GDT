using UnityEngine;
using GDT.Core;

namespace GDT.BallSpace
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallView ballView;
        [SerializeField] private MeshRenderer meshRenderer;

        private BallSorter ballSorter;

        private Vector3 startPosition;
        private int index;
        public int Index => index;

        [HideInInspector] public bool isSorted = false;
        [HideInInspector] public Vector3 desiredPos;

        private void Awake()
        {
            ballSorter = GetComponentInParent<BallSorter>();
            startPosition = transform.position;
        }

        private void OnEnable()
        {
            EventManager.onMenuOpenedEvent += ResetToStartSettings;
            EventManager.onGameRestartedEvent += ResetToStartSettings;
        }

        private void OnDisable()
        {
            EventManager.onMenuOpenedEvent -= ResetToStartSettings;
            EventManager.onGameRestartedEvent -= ResetToStartSettings;
        }

        public void Setup(int index)
        {
            SetIndex(index);
            Color newColor = meshRenderer.material.color;
            meshRenderer.material.color = newColor.SetSaturation(index);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void ResetPositionAndRotation()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        public void SetIndex(int index)
        {
            this.index = index;
            ballView.SetViewData(index);
        }

        private void ResetToStartSettings()
        {
            transform.SetParent(ballSorter.transform, true);
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
            isSorted = false;
        }
    }
}
