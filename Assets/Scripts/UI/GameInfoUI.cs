using UnityEngine;
using TMPro;

namespace GDT.UI
{
    public class GameInfoUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI sortingTimeText;
        [SerializeField] private TextMeshProUGUI currentAlgorithmText;

        public void SetTimeView(float time)
        {
            sortingTimeText.text = time.ToString("0.00");
        }
        public void SetAlgorithmView(string algorithmName)
        {
            currentAlgorithmText.text = algorithmName + " Sort";
        }
    }
}