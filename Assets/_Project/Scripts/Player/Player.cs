using Assets.Scripts.Enemy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamage, IOnDamage, IBuffPicker
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
    private AudioSource _takingDamage;
    private CinemachineImpulseSource _cinemachineImpulseSource;
    private LayerMask _layerMask;

    private List<AudioSource> _audioSources = new();
    private PlayMusic _playMusic;
    private int _numberHealth = 100;
    private float _radius = 0.8f;
    private Collider2D _weaponCollider;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;
    public Flip Flip => _flip;
    public PointHealth PointHealth => _pointHealth;
    public Health Health => _health;
    public Collider2D WeaponCollider => _weaponCollider;

    public event Action OnHit;
    public event Action<int> OnDamage;

    private void Update()
    {
        _playerStateMachine.Update();
        _healthView.FollowTargetHealth();
    }

    private void FixedUpdate() =>
        _weaponCollider = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);

    public void Initialize()
    {
        _playerView.Initialize();
        _flip = new Flip();
        _playerStateMachine = new PlayerStateMachine(this);
        _health = new Health(_numberHealth);

        _playMusic = new PlayMusic();

        _healthInfo = Instantiate(_healthInfoPrefab);
        _healthInfo.Initialize(_healthUi);

        _healthView = new HealthView(this, _numberHealth, _healthInfo);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    [Inject]
    private void Construct(PlayerView playerView, JoysickForMovement joystickForMovement,
        Canvas healthUi, HealthInfo healthInfo, AudioSource takingDamage, CinemachineImpulseSource cinemachineImpulseSource,
        LayerMask layerMask)
    {
        _playerView = playerView;
        _joystickForMovement = joystickForMovement;
        _healthUi = healthUi;
        _healthInfoPrefab = healthInfo;
        _takingDamage = takingDamage;
        _cinemachineImpulseSource = cinemachineImpulseSource;
        _layerMask = layerMask;
    }

    public void Damage(int damage)
    {
        OnHit?.Invoke();
        OnDamage?.Invoke(damage);

        AudioSource audioSource = _playMusic.GetAvailableAudioSource(_audioSources, _takingDamage, transform);
        audioSource.Play();

        _cinemachineImpulseSource.GenerateImpulse();

        _health.TakeDamage(damage);
    }

    public void AddHealth(int value)
    {
        int healthAfterHealing = _numberHealth - value;

        if (healthAfterHealing >= _health.HealthValue)
        {
            _health.AddHealth(value);
            _healthView.AddHealth(value);
        }

        Debug.Log(_health.HealthValue);
    }
}
