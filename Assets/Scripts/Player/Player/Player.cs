using Assets.Scripts.Enemy;
using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamage
{
    private PlayerView _playerView;
    private JoysickForMovement _joystickForMovement;
    private PlayerStateMachine _playerStateMachine;
    private Health _health;
    private Flip _flip;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;
    public Flip Flip => _flip;

    public event Action OnHit;

    private void Awake()
    {
        _playerView.Initialize();
        _flip = new Flip();
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
        OnHit?.Invoke();

        _health.TakeDamage(damage);
        Debug.Log(_health.HealthValue);
    }
}
