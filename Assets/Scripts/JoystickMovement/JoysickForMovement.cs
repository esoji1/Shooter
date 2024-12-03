using Assets.Scripts.JoystickMovement.Player.StateMachine;
using UnityEngine;
using Zenject;

public class JoysickForMovement : JoystickHandler
{
    private PlayerMovement _playerMovement;
    private PlayerView _playerView;

    private PlayerStateMachine _playerStateMachine;

    public Vector2 InputVector => _inputVector;
    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerView PlayerView => _playerView;

    private void Awake()
    {
        _playerView.Initialize();
        _playerStateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
            _playerMovement.MovePlayer(new Vector2(_inputVector.x, _inputVector.y));

        _playerStateMachine.Update();
        _playerStateMachine.Enter();
    }

    [Inject]
    private void Construct(PlayerMovement playerMovement, PlayerView playerView)
    {
        _playerMovement = playerMovement;
        _playerView = playerView;
    }
}