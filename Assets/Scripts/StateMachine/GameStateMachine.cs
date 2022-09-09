using GDT.Statemachine.States;
using UnityEngine;

namespace GDT.Statemachine
{
    public class GameStateMachine : MonoBehaviour
    {
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
        private void OnDestroy()
        {
            currentState.ExitState();
        }
    }
}