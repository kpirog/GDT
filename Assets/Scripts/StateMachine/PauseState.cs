using GDT.Core;
using UnityEngine;

namespace GDT.Statemachine.States
{
    public class PauseState : BaseState
    {
        public PauseState(GameStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void EnterState()
        {
            EventManager.onGameResumedEvent += ResumeGame;
            EventManager.onMenuOpenedEvent += BackToMainMenu;
            EventManager.onGameRestartedEvent += RestartGame;
            Time.timeScale = 0f;
        }

        public override void ExitState()
        {
            EventManager.onGameResumedEvent -= ResumeGame;
            EventManager.onMenuOpenedEvent -= BackToMainMenu;
            EventManager.onGameRestartedEvent -= RestartGame;
            Time.timeScale = 1f;
        }

        private void ResumeGame()
        {
            stateMachine.SwitchState(new GameState(stateMachine));
        }

        private void BackToMainMenu()
        {
            stateMachine.SwitchState(new MenuState(stateMachine));
        }

        private void RestartGame()
        {
            stateMachine.SwitchState(new GameState(stateMachine));
        }
    }
}