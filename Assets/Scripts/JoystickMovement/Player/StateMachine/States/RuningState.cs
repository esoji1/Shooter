
public class RuningState : MovementState
{
    public RuningState(IStateSwitcher stateSwitcher, Player player)
        : base(stateSwitcher, player)
    {
    }

    public override void Update()
    {
        base.Update();

        PlayerView.StopAllAnimations();

        StartRunAnimation();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitcherState<IdleState>();
    }
}