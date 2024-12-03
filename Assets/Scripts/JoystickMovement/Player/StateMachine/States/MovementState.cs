using UnityEngine;

namespace Assets.Scripts.JoystickMovement.Player.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly JoysickForMovement JoysickForMovement;

        private Vector2 _lastDirection = Vector2.down;

        protected MovementState(IStateSwitcher stateSwitcher, JoysickForMovement joysickForMovement)
        {
            StateSwitcher = stateSwitcher;
            JoysickForMovement = joysickForMovement;
        }

        public Vector2 InputVector => JoysickForMovement.InputVector;
        public PlayerView PlayerView => JoysickForMovement.PlayerView;

        public virtual void Enter()
        {
            PlayerView.StopAllAnimations();
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            if (InputVector.x != 0 || InputVector.y != 0)
                JoysickForMovement.PlayerMovement.MovePlayer(new Vector2(InputVector.x, InputVector.y));
        }

        protected bool IsHorizontalInputZero() => InputVector == Vector2.zero;

        protected void StartIdleAnimation()
        {
            if (_lastDirection == Vector2.up)
            {
                PlayerView.StartIdleUp();
            }
            else if (_lastDirection == Vector2.down)
            {
                PlayerView.StartIdleDown();
            }
            else if (_lastDirection == Vector2.left)
            {
                PlayerView.StartIdleLeft();
            }
            else if (_lastDirection == Vector2.right)
            {
                PlayerView.StartIdleRight();
            }
        }

        protected void StartRunAnimation(Vector2 input)
        {
            if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
            {
                if (input.y > 0f)
                {
                    PlayerView.StartRunUp();
                    _lastDirection = Vector2.up;
                }
                else if (input.y < 0f)
                {
                    PlayerView.StartRunDown();
                    _lastDirection = Vector2.down;
                }
            }
            else
            {
                if (input.x > 0f)
                {
                    PlayerView.StartRunRigth();
                    _lastDirection = Vector2.right;
                }
                else if (input.x < 0f)
                {
                    PlayerView.StartRunLeft();
                    _lastDirection = Vector2.left;
                }
            }
        }
    }
}