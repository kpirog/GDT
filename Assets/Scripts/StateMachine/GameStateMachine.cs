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
            ballSorter.SetAlgorithm((AlgorithmType)mainMenu.DropdownValue);
        }
        public void ToggleMenu(bool open)
        {
            mainMenu.TogglePanel(open);
        }
        private void OnDestroy()
        {
            currentState.ExitState();
        }
    }
}