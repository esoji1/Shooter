using UnityEngine;
using Zenject;

public class JoysickForMovement : JoystickHandler
{
    private PlayerMovement _playerMovement;

    public Vector2 InputVector => _inputVector;
    public PlayerMovement PlayerMovement => _playerMovement;

    [Inject]
    private void Construct(PlayerMovement playerMovement) =>
        _playerMovement = playerMovement;
}