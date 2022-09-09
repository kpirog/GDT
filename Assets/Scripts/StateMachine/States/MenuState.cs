using UnityEngine;

namespace GDT.Statemachine.States
{
    public class MenuState : BaseState
    {
        public MenuState(GameStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void EnterState()
        {
            Debug.Log("Menu State");
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {

        }
    }
}
