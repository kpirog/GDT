using UnityEngine;

namespace GDT.Ball
{
    public class Ball : MonoBehaviour
    {
        private int index;

        private MeshRenderer meshRenderer;

        public int Index => index;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private Color ConvertColor(int saturation)
        {
            Color.RGBToHSV(meshRenderer.material.color, out float h, out float s, out float v);
            return Color.HSVToRGB(h, saturation * 0.01f, v);
        }

        public void Setup(int index)
        {
            SetIndex(index);
            meshRenderer.material.color = ConvertColor(index);
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
