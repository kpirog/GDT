using UnityEngine;

namespace GDT.Statemachine.States
{
    public class FinishState : BaseState
    {
        public FinishState(GameStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void EnterState()
        {
            Debug.Log("Finish state");
            stateMachine.OpenFinishMenu();
            Time.timeScale = 0f;
            EventManager.onMenuOpenedEvent += BackToMainMenu;
            EventManager.onGameRestartedEvent += RestartGame;
        }

        public override void ExitState()
        {
            Time.timeScale = 1f;
            EventManager.onMenuOpenedEvent -= BackToMainMenu;
            EventManager.onGameRestartedEvent -= RestartGame;
        }

        public override void UpdateState()
        {

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