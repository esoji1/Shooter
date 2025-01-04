
public class RuningState : MovementState
{
    public RuningState(IStateSwitcher stateSwitcher, Player player)
        : base(stateSwitcher, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        PlayerView.StartRuning();
    }

    public override void Exit()
    {
        base.Exit();

        PlayerView.StopRuning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitcherState<IdleState>();
    }
}