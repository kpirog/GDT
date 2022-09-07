using UnityEngine;
using GDT.Extensions;

namespace GDT.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        private int index;
        public int Index => index;

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

        public void SetIndex(int index)
        {
            this.index = index;
        }
    }
}
