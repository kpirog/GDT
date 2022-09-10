using UnityEngine;

namespace GDT.Statemachine.States
{
    public class GameState : BaseState
    {
        public GameState(GameStateMachine stateMachine) : base(stateMachine)
        {

        }
        
        public override void EnterState()
        {
            Debug.Log("Game State");
            EventManager.onGamePausedEvent += PauseGame;
            EventManager.onSortingFinishedEvent += FinishGame;
        }

        public override void ExitState()
        {
            EventManager.onGamePausedEvent -= PauseGame;
            EventManager.onSortingFinishedEvent -= FinishGame;
        }

        public override void UpdateState()
        {
            
        }
        private void PauseGame()
        {
            stateMachine.SwitchState(new PauseState(stateMachine));
        }
        private void FinishGame()
        {
            stateMachine.SwitchState(new FinishState(stateMachine));
        }
    }
}