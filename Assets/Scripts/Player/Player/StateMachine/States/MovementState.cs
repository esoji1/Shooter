using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly JoysickForMovement JoysickForMovement;
    private Player _player;
    private Flip _flip;

    protected Vector2 LastDirection = Vector2.down;

    protected MovementState(IStateSwitcher stateSwitcher, Player player)
    {
        StateSwitcher = stateSwitcher;
        JoysickForMovement = player.JoysickForMovement;
        _player = player;
        _flip = player.Flip;
    }

    public Vector2 InputVector => JoysickForMovement.InputVector;
    public PlayerView PlayerView => _player.PlayerView;
    public Player Player => _player;

    public virtual void Enter()
    {
        _player.OnHit += GoHitState;
    }

    public virtual void Exit()
    {
        _player.OnHit -= GoHitState;
    }

    public virtual void Update()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
            JoysickForMovement.PlayerMovement.MovePlayer(new Vector2(InputVector.x, InputVector.y));
        
        if(IsHorizontalInputZero() == false)
            _flip.FlipSpriteY(InputVector, _player.PlayerView.SpriteRenderer);
    }

    protected bool IsHorizontalInputZero() => InputVector == Vector2.zero;

    private void GoHitState() => StateSwitcher.SwitcherState<HitState>();
}