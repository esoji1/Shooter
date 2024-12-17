using Assets.Scripts.Enemy;
using System.Collections;
using UnityEngine;

public class Orc : MonoBehaviour, IDamage
{
    private EnemyMeleeConfig _config;
    private Player _target;
    private OrcView _orcView;

    private bool _isDie = false;

    private Coroutine _coroutine;
    private BoxCollider2D _boxCollider2D;

    private Health _health;
    private ChangeEnemyPosition _changeEnemyPosition;
    private Flip _flip;

    private void Awake()
    {
        _health = new Health(100);
        _changeEnemyPosition = new ChangeEnemyPosition();
        _flip = new Flip();
    }

    private void Start()
    {
        _orcView.Initialize();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        StartCoroutine(_changeEnemyPosition.SetRandomPosition(_config.AttackRadius));
    }

    private void Update()
    {
        if (_target == null || _isDie)
            return;

        HandleMovementAndAttack();
    }

    private void OnEnable()
    {
        _health.OnDie += Die;
    }

    private void OnDisable()
    {
        _health.OnDie -= Die;
    }

    public void Initialize(EnemyMeleeConfig config, Player target)
    {
        _config = config;
        _target = target;

        _orcView = transform.GetComponentInChildren<OrcView>();
    }

    public void Damage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void HandleMovementAndAttack()
    {
        float distance = Vector2.Distance(transform.position, _target.transform.position);
        Vector2 direction = (_target.transform.position - transform.position).normalized;

        _flip.FlipSpriteY(direction, _orcView.SpriteRenderer);

        if (distance > _config.AttackRadius)
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
        _orcView.StopAttack();
        _orcView.StartWalk();

        Vector3 targetPosition = _target.transform.position + _changeEnemyPosition.AddRandomPositionToGo;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _config.Speed * Time.deltaTime);
    }

    private void StopAttackIfNeeded()
    {
        if (_coroutine != null)
        {
            _orcView.StopAttack();
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAttackIfNeeded()
    {
        if (_coroutine == null)
        {
            _orcView.StopWalk();
            _coroutine = StartCoroutine(DelayBeforeAttack());
        }
    }

    private IEnumerator DelayBeforeAttack()
    {
        while (true)
        {
            _orcView.StartAttack();

            float attackAnimationTime = _orcView.Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackAnimationTime);

            TryDealDamageToTarget();
        }
    }

    private void TryDealDamageToTarget()
    {
        if (_target.TryGetComponent(out IDamage damage))
        {
            _orcView.StartAttack();
            damage.Damage(_config.Damage);
        }
    }

    private void Die()
    {
        StopAttackIfNeeded();

        float removingnemy = 5f;

        _isDie = true;
        _boxCollider2D.enabled = false;

        _orcView.PlayDie();

        Destroy(gameObject, removingnemy);
    }
}
