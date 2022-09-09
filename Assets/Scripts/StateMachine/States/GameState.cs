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
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            
        }
    }
}