using UnityEngine;
using GDT.Extensions;

namespace GDT.Elements
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        private int index;
        public int Index => index;

        public bool isSorted = false;

        public Vector3 desiredPos;

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
        }
    }
}
