using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private JoysickForMovement _joysickForMovement;
    [SerializeField] private PlayerView _playerView;

    private Vector2 _lastDirection = Vector2.down; 

    private void Awake()
    {
        _playerView.Initialize();
    }

    private void Update()
    {
        Vector2 input = _joysickForMovement.InputVector;

        StopAllAnimations();

        if (input == Vector2.zero)
        {
            StartIdleAnimation();
        }
        else
        {
            StartRunAnimation(input);
        }
    }

    private void StopAllAnimations()
    {
        _playerView.StopRunRigth();
        _playerView.StopRunLeft();
        _playerView.StopRunUp();
        _playerView.StopRunDown();

        _playerView.StopIdleUp();
        _playerView.StopIdleDown();
        _playerView.StopIdleLeft();
        _playerView.StopIdleRight();
    }

    private void StartIdleAnimation()
    {
        if (_lastDirection == Vector2.up)
        {
            _playerView.StartIdleUp();
        }
        else if (_lastDirection == Vector2.down)
        {
            _playerView.StartIdleDown();
        }
        else if (_lastDirection == Vector2.left)
        {
            _playerView.StartIdleLeft();
        }
        else if (_lastDirection == Vector2.right)
        {
            _playerView.StartIdleRight();
        }
    }

    private void StartRunAnimation(Vector2 input)
    {
        if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
        {
            if (input.y > 0f)
            {
                _playerView.StartRunUp();
                _lastDirection = Vector2.up; 
            }
            else if (input.y < 0f)
            {
                _playerView.StartRunDown();
                _lastDirection = Vector2.down; 
            }
        }
        else
        {
            if (input.x > 0f)
            {
                _playerView.StartRunRigth();
                _lastDirection = Vector2.right; 
            }
            else if (input.x < 0f)
            {
                _playerView.StartRunLeft();
                _lastDirection = Vector2.left;
            }
        }
    }
}