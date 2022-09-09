namespace GDT.Statemachine.States
{
    public abstract class BaseState 
    {
        protected GameStateMachine stateMachine;

        protected BaseState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
    }
}