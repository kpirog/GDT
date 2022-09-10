using UnityEngine;
using TMPro;

namespace GDT.BallSpace
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