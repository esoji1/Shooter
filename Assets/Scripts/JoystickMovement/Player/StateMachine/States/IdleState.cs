namespace Assets.Scripts.JoystickMovement.Player.StateMachine.States
{
    public class IdleState : MovementState
    {
        public IdleState(IStateSwitcher stateSwitcher, JoysickForMovement joysickForMovement) : base(stateSwitcher, joysickForMovement)
        {

        }

        public override void Enter()
        {
            base.Enter();

            StartIdleAnimation();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalInputZero() == false)
                StateSwitcher.SwitcherState<RuningState>();
        }
    }
}
