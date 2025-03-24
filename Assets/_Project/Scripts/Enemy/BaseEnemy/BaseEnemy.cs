using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveWhileAttacking), typeof(AttackFactory))]
public abstract class BaseEnemy : MonoBehaviour, IDamage, IOnDamage
{
    protected EnemyConfig Config;
    protected BaseViewEnemy BaseView;
    protected Player Target;
    protected Health Health;
    protected HealthView HealthView;

    private Canvas _healthUi;
    private AudioSource _takingDamage;
    private bool _isDie = false;
    private Vector2 _direction;
    private List<AudioSource> _audioSources = new();
    private Hilka _hilka;
    private int _spawnProbability = 20;
    private bool _isMove;


    private BoxCollider2D _boxCollider2D;
    private ChangeEnemyPosition _changeEnemyPosition;
    private Flip _flip;
    private HealthInfo _healthInfo;
    private PlayMusic _playMusic;
    private SpawnWithProbability _spawnWithProbability;
    private PointAttack _pointAttack;

    protected abstract PointHealth Point { get; }
    
    public Vector2 Direction => _direction;
    public PointHealth PointHealth => Point;
    public BaseViewEnemy GetBaseView => BaseView;
    public EnemyConfig GetConfig => Config;
    public Transform GetTarget => Target.transform;
    public bool IsDie => _isDie;
    public ChangeEnemyPosition ChangeEnemyPosition => _changeEnemyPosition;
    public Flip Flip => _flip;
    public Health GetHealth => Health;
    public HealthView GetHealthView => HealthView;
    public PointAttack PointAttack => _pointAttack;
    public bool IsMove => _isMove;

    public event Action<BaseEnemy> OnEnemyDie;
    public event Action<int> OnDamage;

    protected virtual void Update()
    {
        if (Target == null || _isDie)
            return;

        HealthView.FollowTargetHealth();
        _direction = (Target.transform.position - transform.position).normalized;
    }

    public virtual void Initialize(EnemyConfig config, Player target, HealthInfo healthInfo, Canvas healthUi,
        AudioSource takingDamage, Hilka hilka)
    {
        ExtractComponents();

        Target = target;
        Config = config;
        _healthUi = healthUi;
        _takingDamage = takingDamage;
        _hilka = hilka;
        _isMove = true;

        _playMusic = new PlayMusic();

        _healthInfo = Instantiate(healthInfo);
        _healthInfo.Initialize(_healthUi);
        HealthView = new HealthView(this, config.Health, _healthInfo);

        _changeEnemyPosition = new ChangeEnemyPosition();
        _flip = new Flip();

        BaseView.Initialize();

        StartCoroutine(_changeEnemyPosition.SetRandomPosition(Config.AttackRadius));

        Health = new Health(Config.Health);
        _spawnWithProbability = new SpawnWithProbability(_hilka);

        Health.OnDie += Die;
    }

    public void Damage(int damage)
    {
        OnDamage?.Invoke(damage);

        AudioSource audioSource = _playMusic.GetAvailableAudioSource(_audioSources, _takingDamage, transform);
        audioSource.Play();

        Health.TakeDamage(damage);
    }

    public void SetMove(bool value) => _isMove = value;

    private void ExtractComponents()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _pointAttack = GetComponentInChildren<PointAttack>();
        BaseView = transform.GetComponentInChildren<BaseViewEnemy>();
    }

    private void Die()
    {
        OnEnemyDie?.Invoke(this);

        float removingEnemy = 5f;

        _isDie = true;
        _boxCollider2D.enabled = false;

        BaseView.PlayDie();

        Health.OnDie -= Die;

        _spawnWithProbability.SpawnWithProbabilityInPercent(_spawnProbability, transform);

        Destroy(_healthInfo.InstantiatedHealthBar, removingEnemy);
        Destroy(_healthInfo.GetHealthInfo.gameObject, removingEnemy);
        Destroy(gameObject, removingEnemy);
    }
}
