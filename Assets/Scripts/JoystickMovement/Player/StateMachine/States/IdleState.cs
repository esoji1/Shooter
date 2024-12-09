
public class IdleState : MovementState
{
    public IdleState(IStateSwitcher stateSwitcher, Player player)
        : base(stateSwitcher, player)
    {

    }
    public override void Update()
    {
        base.Update();

        PlayerView.StopAllAnimations();

        StartIdleAnimation();

        if (IsHorizontalInputZero() == false)
            StateSwitcher.SwitcherState<RuningState>();
    }
}