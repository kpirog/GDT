using UnityEngine;
using TMPro;
using DG.Tweening;

namespace GDT.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private RectTransform titleTransform;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TMP_Dropdown algorithmDropdown;
        [SerializeField] private float titleAnimationDuration = 2f;

        public int DropdownValue => algorithmDropdown.value;

        private void Start()
        {
            TitleAnimation();
        }

        private void TitleAnimation()
        {
            Sequence titleAnimationSequence = DOTween.Sequence();

            titleAnimationSequence
                .Append(titleTransform.DOScale(0.5f, titleAnimationDuration))
                .Append(titleTransform.DOScale(1f, titleAnimationDuration))
                .SetLoops(-1, LoopType.Restart);

            Sequence titleTextSequence = DOTween.Sequence();

            titleTextSequence
                .Append(titleText.DOColor(Color.blue, titleAnimationDuration))
                .Append(titleText.DOColor(Color.white, titleAnimationDuration))
                .SetLoops(-1, LoopType.Restart);
        }
        public void StartButton()
        {
            EventManager.OnGameStarted();
        }
        public void OptionsButton()
        {

        }
        public void ExitButton()
        {
            Application.Quit();
        }
        public void TogglePanel(bool open)
        {
            menuPanel.SetActive(open);
        }
    }
}