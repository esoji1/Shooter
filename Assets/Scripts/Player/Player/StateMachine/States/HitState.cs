using System.Collections;
using UnityEngine;

public class HitState : MovementState
{
    public HitState(IStateSwitcher stateSwitcher, Player player)
        : base(stateSwitcher, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        PlayerView.PlayHit();

        Player.StartCoroutine(ReturnToPreviousStateAfterHit());
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
    }

    private IEnumerator ReturnToPreviousStateAfterHit()
    {
        AnimatorStateInfo stateInfo = PlayerView.Animator.GetCurrentAnimatorStateInfo(0);

        yield return new WaitForSeconds(stateInfo.length);

        if (IsHorizontalInputZero())
            StateSwitcher.SwitcherState<IdleState>();
        else
            StateSwitcher.SwitcherState<RuningState>();
    }
}
