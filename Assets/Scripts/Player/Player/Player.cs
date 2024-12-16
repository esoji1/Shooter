using Assets.Scripts.Enemy;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamage
{
    private PlayerView _playerView;
    private JoysickForMovement _joystickForMovement;
    private PlayerStateMachine _playerStateMachine;
    private Health _health;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;

    private void Awake()
    {
        _playerView.Initialize();
        _playerStateMachine = new PlayerStateMachine(this);
        _health = new Health(100);
    }

    private void Update()
    {
        _playerStateMachine.Update();
    }


    [Inject]
    private void Construct(PlayerView playerView, JoysickForMovement joystickForMovement)
    {
        _playerView = playerView;
        _joystickForMovement = joystickForMovement;
    }

    public void Damage(int damage)
    {
        _playerView.PlayHit();

        _health.TakeDamage(damage);
        Debug.Log(_health.HealthValue);

        StartCoroutine(ReturnToPreviousStateAfterHit());
    }

    private IEnumerator ReturnToPreviousStateAfterHit()
    {
        AnimatorStateInfo stateInfo = _playerView.Animator.GetCurrentAnimatorStateInfo(0);

        yield return new WaitForSeconds(stateInfo.length);

        if (JoysickForMovement.InputVector == Vector2.zero)
            _playerStateMachine.SwitcherState<IdleState>();
        else
            _playerStateMachine.SwitcherState<RuningState>();
    }
}
