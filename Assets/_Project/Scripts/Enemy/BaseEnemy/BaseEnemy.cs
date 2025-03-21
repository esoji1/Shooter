using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveWhileAttacking), typeof(AttackControl))]
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

    private Coroutine _coroutine;
    private BoxCollider2D _boxCollider2D;

    private ChangeEnemyPosition _changeEnemyPosition;
    private Flip _flip;
    private HealthInfo _healthInfo;
    private PlayMusic _playMusic;
    private SpawnWithProbability _spawnWithProbability;
    private MoveWhileAttacking _moveWhileAttacking;
    private AttackControl _attackControl;

    private int _spawnProbability = 20;

    protected abstract PointHealth Point { get; }

    protected Vector2 Direction => _direction;
    public PointHealth PointHealth => Point;
    public BaseViewEnemy GetBaseView => BaseView;
    public EnemyConfig GetConfig => Config;
    public Transform GetTarget => Target.transform;
    public bool IsDie => _isDie;
    public ChangeEnemyPosition ChangeEnemyPosition => _changeEnemyPosition;
    public Flip Flip => _flip;
    public Health GetHealth => Health;
    public HealthView GetHealthView => HealthView;

    public event Action<BaseEnemy> OnEnemyDie;
    public event Action<int> OnDamage;

    private void Awake()
        => _boxCollider2D = GetComponent<BoxCollider2D>();

    protected virtual void Update()
    {
        if (Target == null || _isDie)
            return;

        //HandleMovementAndAttack();

        HealthView.FollowTargetHealth();
    }

    public virtual void Initialize(EnemyConfig config, Player target, HealthInfo healthInfo, Canvas healthUi,
        AudioSource takingDamage, Hilka hilka)
    {
        Target = target;
        Config = config;
        _healthUi = healthUi;
        _takingDamage = takingDamage;
        _hilka = hilka;

        _playMusic = new PlayMusic();

        _healthInfo = Instantiate(healthInfo);
        _healthInfo.Initialize(_healthUi);
        HealthView = new HealthView(this, config.Health, _healthInfo);

        _changeEnemyPosition = new ChangeEnemyPosition();
        _flip = new Flip();

        BaseView = transform.GetComponentInChildren<BaseViewEnemy>();
        BaseView.Initialize();

        StartCoroutine(_changeEnemyPosition.SetRandomPosition(Config.AttackRadius));

        Health = new Health(Config.Health);
        _spawnWithProbability = new SpawnWithProbability(hilka);

        _moveWhileAttacking = GetComponent<MoveWhileAttacking>();
        _moveWhileAttacking.Initialize(this);

        _attackControl = GetComponent<AttackControl>();
        _attackControl.Initialize(this);

        Health.OnDie += Die;
    }

    public void Damage(int damage)
    {
        OnDamage?.Invoke(damage);

        AudioSource audioSource = _playMusic.GetAvailableAudioSource(_audioSources, _takingDamage, transform);
        audioSource.Play();

        Health.TakeDamage(damage);
    }

    private void Die()
    {
        OnEnemyDie?.Invoke(this);

        //StopAttackIfNeeded();

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

    //protected abstract void TryDealDamageToTarget();

    //private void HandleMovementAndAttack()
    //{
    //    float distance = Vector2.Distance(transform.position, Target.transform.position);
    //    if (distance > Config.AttackRadius)
    //    {
    //        StopAttackIfNeeded();
    //    }
    //    else
    //    {
    //        StartAttackIfNeeded();
    //    }
    //}

    //private void StopAttackIfNeeded()
    //{
    //    if (_coroutine != null)
    //    {
    //        BaseView.StopAttack();
    //        StopCoroutine(_coroutine);
    //        _coroutine = null;
    //    }
    //}

    //private void StartAttackIfNeeded()
    //{
    //    if (_coroutine == null)
    //    {
    //        BaseView.StopWalk();
    //        _coroutine = StartCoroutine(DelayBeforeAttack());
    //    }
    //}

    //protected virtual IEnumerator DelayBeforeAttack()
    //{
    //    while (true)
    //    {
    //        BaseView.StartAttack();

    //        float attackAnimationTime = BaseView.Animator.GetCurrentAnimatorStateInfo(0).length;
    //        yield return new WaitForSeconds(attackAnimationTime);

    //        TryDealDamageToTarget();
    //    }
    //}
}