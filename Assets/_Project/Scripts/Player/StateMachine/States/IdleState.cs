
public class IdleState : MovementState
{
    public IdleState(IStateSwitcher stateSwitcher, Player player)
        : base(stateSwitcher, player)
    {

    }

    public override void Enter()
    {
        base.Enter();

        PlayerView.StartIdle();
    }

    public override void Exit()
    {
        base.Exit();

        PlayerView.StopIdle();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero() == false)
            StateSwitcher.SwitcherState<RuningState>();
    }
}