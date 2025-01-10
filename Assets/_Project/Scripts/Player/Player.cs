using Assets.Scripts.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    private AudioSource _takingDamage;

    private List<AudioSource> _audioSources = new();
    private PlayMusic _playMusic;

    public PlayerView PlayerView => _playerView;
    public JoysickForMovement JoysickForMovement => _joystickForMovement;
    public Flip Flip => _flip;
    public PointHealth PointHealth => _pointHealth;
    public Health Health => _health;

    public event Action OnHit;
    public event Action<int> OnDamage;
    public event Action<Collider2D> OnEnterCollider;
    public event Action<Collider2D> OnExitCollider;

    private void Update()
    {
        _playerStateMachine.Update();

        _healthView.FollowTargetHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnterCollider?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitCollider?.Invoke(collision);
    }

    public void Initialize()
    {
        _playerView.Initialize();
        _flip = new Flip();
        _playerStateMachine = new PlayerStateMachine(this);
        _health = new Health(100);

        _playMusic = new PlayMusic();

        _healthInfo = Instantiate(_healthInfoPrefab);
        _healthInfo.Initialize(_healthUi);

        _healthView = new HealthView(this, 100, _healthInfo);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    [Inject]
    private void Construct(PlayerView playerView, JoysickForMovement joystickForMovement,
        Canvas healthUi, HealthInfo healthInfo, AudioSource takingDamage)
    {
        _playerView = playerView;
        _joystickForMovement = joystickForMovement;
        _healthUi = healthUi;
        _healthInfoPrefab = healthInfo;
        _takingDamage = takingDamage;
    }

    public void Damage(int damage)
    {
        OnHit?.Invoke();
        OnDamage?.Invoke(damage);

        AudioSource audioSource = _playMusic.GetAvailableAudioSource(_audioSources, _takingDamage, transform);
        audioSource.Play();

        _health.TakeDamage(damage);
    }
}
