using Assets.Scripts.JoystickMovement.Player.StateMachine.States;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.JoystickMovement.Player.StateMachine
{
    public class PlayerStateMachine : IStateSwitcher
    {
        private Dictionary<Type, MovementState> _states;
        private MovementState _currentState;

        public PlayerStateMachine(JoysickForMovement joysickForMovement)
        {
            _states = new Dictionary<Type, MovementState>()
            {
                {typeof(IdleState), new IdleState(this, joysickForMovement)},
                {typeof(RuningState), new RuningState(this, joysickForMovement)},
            };

            _currentState = _states[typeof(RuningState)];
            _currentState.Enter();
        }

        public void SwitcherState<T>() where T : MovementState
        {
            MovementState state = _states[typeof(T)];

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();

        public void Enter() => _currentState.Enter();
    }
}