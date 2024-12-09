using System;
using System.Collections.Generic;

public class PlayerStateMachine : IStateSwitcher
{
    private Dictionary<Type, MovementState> _states;
    private MovementState _currentState;

    public PlayerStateMachine(Player player)
    {
        _states = new Dictionary<Type, MovementState>()
            {
                {typeof(IdleState), new IdleState(this, player)},
                {typeof(RuningState), new RuningState(this, player)},
            };

        _currentState = _states[typeof(RuningState)];
    }

    public void SwitcherState<T>() where T : MovementState
    {
        MovementState state = _states[typeof(T)];

        _currentState = state;
    }

    public void Update() => _currentState.Update();
}