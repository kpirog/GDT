using System;
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
            stateMachine.ToggleMenu(true);
            EventManager.onGameStartedEvent += StartGameplay;
        }

        public override void ExitState()
        {
            EventManager.onGameStartedEvent -= StartGameplay;
        }

        public override void UpdateState()
        {

        }

        private void StartGameplay()
        {
            stateMachine.SetChosenAlgorithm();
            stateMachine.ToggleMenu(false);
            stateMachine.SwitchState(new GameState(stateMachine));
        }
    }
}
