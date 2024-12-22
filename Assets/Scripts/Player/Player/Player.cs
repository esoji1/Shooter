using Assets.Scripts.Enemy;
using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamage, IOnDamage
{
    [SerializeField] private HealthView _healthView;

    private PlayerView _playerView;
    private JoysickForMovement _joystickForMovement;
    private PlayerStateMachine _playerStateMachine;
    private Health _health;
    private Flip _flip;
    private PointHealth _pointHealth;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;
    public Flip Flip => _flip;
    public PointHealth PointHealth => _pointHealth;

    public event Action OnHit;
    public event Action<int> OnDamage;

    private void Awake()
    {
        _playerView.Initialize();
        _flip = new Flip();
        _playerStateMachine = new PlayerStateMachine(this);
        _health = new Health(100);
        _healthView.Initialize(this, 100);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    private void Update()
    {
        _playerStateMachine.Update();

        _healthView.FollowTargetHealth();
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
        OnDamage?.Invoke(damage);

        _health.TakeDamage(damage);
        Debug.Log(_health.HealthValue);
    }
}
