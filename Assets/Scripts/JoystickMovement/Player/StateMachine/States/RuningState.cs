using UnityEngine;

namespace Assets.Scripts.JoystickMovement.Player.StateMachine.States
{
    public class RuningState : MovementState
    {
        public RuningState(IStateSwitcher stateSwitcher, JoysickForMovement joysickForMovement) : base(stateSwitcher, joysickForMovement)
        {
        }

        public override void Enter()
        {
            base.Enter();

            StartRunAnimation(InputVector);
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalInputZero())
                StateSwitcher.SwitcherState<IdleState>();
        }
    }
}