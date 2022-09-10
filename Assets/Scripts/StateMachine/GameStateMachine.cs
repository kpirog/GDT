using GDT.Elements;
using GDT.Statemachine.States;
using GDT.UI;
using GDT.Algorithms;
using UnityEngine;

namespace GDT.Statemachine
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private BallSorter ballSorter;
        [SerializeField] private GameInfoUI gameInfoUI;
        [SerializeField] private FinishMenu finishMenu;
        
        private BaseState currentState;

        private void Start()
        {
            SwitchState(new MenuState(this));
        }
        private void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }
        public void SwitchState(BaseState newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }

            currentState = newState;
            currentState.EnterState();
        }
        public void SetChosenAlgorithm()
        {
            AlgorithmType algorithmType = (AlgorithmType)mainMenu.DropdownValue;
            ballSorter.SetAlgorithm(algorithmType);
            gameInfoUI.SetAlgorithmView(algorithmType.ToString());
        }
        public void ToggleMenu(bool open)
        {
            mainMenu.TogglePanel(open);
        }
        public void OpenFinishMenu()
        {
            finishMenu.TogglePanel(true);
        }
        private void OnDestroy()
        {
            currentState.ExitState();
        }
    }
}