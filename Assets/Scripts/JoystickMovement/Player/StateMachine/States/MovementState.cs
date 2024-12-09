using UnityEngine;
using Zenject.SpaceFighter;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly JoysickForMovement JoysickForMovement;
    private Player _player;

    protected Vector2 LastDirection = Vector2.down;

    protected MovementState(IStateSwitcher stateSwitcher, Player player)
    {
        StateSwitcher = stateSwitcher;
        JoysickForMovement = player.JoysickForMovement;
        _player = player;
    }

    public Vector2 InputVector => JoysickForMovement.InputVector;
    public PlayerView PlayerView => _player.PlayerView;

    public virtual void Update()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
            JoysickForMovement.PlayerMovement.MovePlayer(new Vector2(InputVector.x, InputVector.y));
    }

    protected bool IsHorizontalInputZero() => InputVector == Vector2.zero;

    protected void StartIdleAnimation()
    {
        if (LastDirection == Vector2.up)
        {
            PlayerView.StartIdleUp();
        }
        else if (LastDirection == Vector2.down)
        {
            PlayerView.StartIdleDown();
        }
        else if (LastDirection == Vector2.left)
        {
            PlayerView.StartIdleLeft();
        }
        else if (LastDirection == Vector2.right)
        {
            PlayerView.StartIdleRight();
        }
    }

    protected void StartRunAnimation()
    {
        if (Mathf.Abs(InputVector.y) > Mathf.Abs(InputVector.x))
        {
            if (InputVector.y > 0f)
            {
                PlayerView.StartRunUp();
                LastDirection = Vector2.up;
            }
            else if (InputVector.y < 0f)
            {
                PlayerView.StartRunDown();
                LastDirection = Vector2.down;
            }
        }
        else
        {
            if (InputVector.x > 0f)
            {
                PlayerView.StartRunRigth();
                LastDirection = Vector2.right;
            }
            else if (InputVector.x < 0f)
            {
                PlayerView.StartRunLeft();
                LastDirection = Vector2.left;
            }
        }
    }
}