using UnityEngine;
using TMPro;

namespace GDT.Elements
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI indexText;

        public void SetViewData(int index)
        {
            indexText.text = index.ToString();
        }
    }
}