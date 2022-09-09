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
            Debug.Log("Pause State");
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {

        }
    }
}