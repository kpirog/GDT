using GDT.Core;
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
            stateMachine.ToggleMenu(true);
            EventManager.onGameStartedEvent += StartGameplay;
        }

        public override void ExitState()
        {
            EventManager.onGameStartedEvent -= StartGameplay;
        }

        private void StartGameplay()
        {
            stateMachine.SetChosenAlgorithm();
            stateMachine.ToggleMenu(false);
            stateMachine.SwitchState(new GameState(stateMachine));
        }
    }
}
