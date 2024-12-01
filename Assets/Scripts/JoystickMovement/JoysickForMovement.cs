using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JoysickForMovement : JoystickHandler
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpriteRenderer _player;

    private void Update()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
            _playerMovement.MovePlayer(new Vector2(_inputVector.x, _inputVector.y));

        Flipplayer();
    }

    private void Flipplayer()
    {
        float dotProduct = Vector3.Dot(_inputVector, transform.right);

        if (dotProduct < 0f)
            _player.flipX = true;
     
        else if (dotProduct > 0f)
            _player.flipX = false;
    }
}