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

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
            JoysickForMovement.PlayerMovement.MovePlayer(new Vector2(InputVector.x, InputVector.y));

        FlipSpritePlayer();
    }

    protected bool IsHorizontalInputZero() => InputVector == Vector2.zero;

    private void FlipSpritePlayer()
    {
        if(InputVector.x < 0f)
        {
            PlayerView.GetSpriteRenderer.flipX = true;
        }
        else if (InputVector.x > 0f)
        {
            PlayerView.GetSpriteRenderer.flipX = false;
        }
    }
}