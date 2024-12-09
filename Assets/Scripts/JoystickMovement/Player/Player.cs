using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private PlayerView _playerView;
    private JoysickForMovement _joystickForMovement;
    private PlayerStateMachine _playerStateMachine;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;

    private void Awake()
    {
        _playerView.Initialize();
        _playerStateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        _playerStateMachine.Update();
    }

    [Inject]
    private void Construct(PlayerView playerView, JoysickForMovement joystickForMovement)
    {
        _playerView = playerView;
        _joystickForMovement = joystickForMovement;
    }
}