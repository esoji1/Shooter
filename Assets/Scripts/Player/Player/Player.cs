using Assets.Scripts.Enemy;
using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamage, IOnDamage
{
    private PlayerView _playerView;
    private JoysickForMovement _joystickForMovement;
    private PlayerStateMachine _playerStateMachine;
    private Health _health;
    private Flip _flip;
    private PointHealth _pointHealth;
    private Canvas _healthUi;
    private HealthView _healthView;
    private HealthInfo _healthInfoPrefab;
    private HealthInfo _healthInfo;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;
    public Flip Flip => _flip;
    public PointHealth PointHealth => _pointHealth;
    public Health Health => _health;

    public event Action OnHit;
    public event Action<int> OnDamage;

    private void Update()
    {
        _playerStateMachine.Update();

        _healthView.FollowTargetHealth();
    }

    public void Initialize()
    {
        _playerView.Initialize();
        _flip = new Flip();
        _playerStateMachine = new PlayerStateMachine(this);
        _health = new Health(100);

        _healthInfo = Instantiate(_healthInfoPrefab);
        _healthInfo.Initialize(_healthUi);

        _healthView = new HealthView(this, 100, _healthInfo);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    [Inject]
    private void Construct(PlayerView playerView, JoysickForMovement joystickForMovement,
        Canvas healthUi, HealthInfo healthInfo)
    {
        _playerView = playerView;
        _joystickForMovement = joystickForMovement;
        _healthUi = healthUi;
        _healthInfoPrefab = healthInfo;
    }

    public void Damage(int damage)
    {
        OnHit?.Invoke();
        OnDamage?.Invoke(damage);

        _health.TakeDamage(damage);
        Debug.Log(_health.HealthValue);
    }
}
