using Assets.Scripts.Enemy;
using System;
using System.Collections;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamage
{
    protected EnemyConfig Config;
    protected BaseViewEnemy BaseView;
    protected Player Target;
    protected Health Health;

    private bool _isDie = false;
    private Vector2 _direction;

    private Coroutine _coroutine;
    private BoxCollider2D _boxCollider2D;

    private ChangeEnemyPosition _changeEnemyPosition;
    private Flip _flip;

    protected Vector2 Direction => _direction;

    public event Action<BaseEnemy> OnEnemyDie;

    private void Awake()
    {
        _changeEnemyPosition = new ChangeEnemyPosition();
        _flip = new Flip();
    }

    private void Start()
    {
        BaseView.Initialize();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        StartCoroutine(_changeEnemyPosition.SetRandomPosition(Config.AttackRadius));
    }

    protected virtual void Update()
    {
        if (Target == null || _isDie)
            return;

        HandleMovementAndAttack();
    }

    public virtual void Initialize(EnemyConfig config, Player target)
    {
        Target = target;
        Config = config;

        BaseView = transform.GetComponentInChildren<BaseViewEnemy>();

        Health = new Health(Config.Health);

        Health.OnDie += Die;
    }

    public void Damage(int damage)
    {
        Health.TakeDamage(damage);
    }

    protected void Die()
    {
        OnEnemyDie?.Invoke(this);

        StopAttackIfNeeded();

        float removingnemy = 5f;

        _isDie = true;
        _boxCollider2D.enabled = false;

        BaseView.PlayDie();

        Health.OnDie -= Die;

        Destroy(gameObject, removingnemy);
    }

    protected abstract void TryDealDamageToTarget();

    private void HandleMovementAndAttack()
    {
        float distance = Vector2.Distance(transform.position, Target.transform.position);
        _direction = (Target.transform.position - transform.position).normalized;

        _flip.FlipSpriteY(_direction, BaseView.SpriteRenderer);

        if (distance > Config.AttackRadius)
        {
            MoveTowardsTarget();
            StopAttackIfNeeded();
        }
        else
        {
            StartAttackIfNeeded();
        }
    }

    private void MoveTowardsTarget()
    {
        BaseView.StopAttack();
        BaseView.StartWalk();

        Vector3 targetPosition = Target.transform.position + _changeEnemyPosition.AddRandomPositionToGo;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Config.Speed * Time.deltaTime);
    }

    private void StopAttackIfNeeded()
    {
        if (_coroutine != null)
        {
            BaseView.StopAttack();
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAttackIfNeeded()
    {
        if (_coroutine == null)
        {
            BaseView.StopWalk();
            _coroutine = StartCoroutine(DelayBeforeAttack());
        }
    }

    private IEnumerator DelayBeforeAttack()
    {
        while (true)
        {
            BaseView.StartAttack();

            float attackAnimationTime = BaseView.Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackAnimationTime);

            TryDealDamageToTarget();
        }
    }
}