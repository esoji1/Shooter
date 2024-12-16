using Assets.Scripts.Enemy;
using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour, IDamage
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackRadius = 2f;
    [SerializeField] private SkeletonView _skeletonView;

    private int _damage = 10;
    private Coroutine _coroutine;
    private bool _isDie = false;
    private BoxCollider2D _boxCollider2D;
    private float _distanceFromEnemy = 2.2f;

    private Health _health;
    private ChangeEnemyPosition _changeEnemyPosition;

    private void Awake()
    {
        _health = new Health(100);
        _skeletonView.Initialize();
        _changeEnemyPosition = new ChangeEnemyPosition();
    }

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(_changeEnemyPosition.SetRandomPosition(_distanceFromEnemy));
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (_isDie && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        if (_isDie == false)
        {
            float distance = Vector2.Distance(transform.position, _target.transform.position);
            Vector2 direction = (_target.transform.position - transform.position).normalized;

            FlipSprite(direction);

            if (distance > _attackRadius)
            {
                MoveTowardsTarget(direction);

                if (_coroutine != null)
                {
                    _skeletonView.StopAttack();
                    StopCoroutine(_coroutine);
                    _coroutine = null;
                }
            }
            else
            {
                if (_coroutine == null)
                {
                    _skeletonView.StopWalk();
                    _coroutine = StartCoroutine(DelayBeforeAttack());
                }
            }
        }
    }

    private void OnEnable()
    {
        _health.OnDie += Die;
    }

    private void OnDisable()
    {
        _health.OnDie -= Die;
    }

    public void Damage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void MoveTowardsTarget(Vector2 direction)
    {
        _skeletonView.StopAttack();
        _skeletonView.StartWalk();

        transform.position = Vector2.MoveTowards(transform.position,
            _target.transform.position + _changeEnemyPosition.AddRandomPositionToGo, _speed * Time.deltaTime);
    }

    private IEnumerator DelayBeforeAttack()
    {

        while (true)
        {
            _skeletonView.StartAttack();

            float attackAnimationTime = _skeletonView.Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackAnimationTime);

            if (_target.TryGetComponent(out IDamage damage))
            {
                _skeletonView.StartAttack();
                damage.Damage(_damage);
            }
        }
    }

    private void FlipSprite(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _skeletonView.SpriteRenderer.flipX = false;
        }
        else if (direction.x > 0)
        {
            _skeletonView.SpriteRenderer.flipX = true;
        }
    }

    private void Die()
    {
        float removingnemy = 5f;

        _isDie = true;
        _boxCollider2D.enabled = false;

        _skeletonView.PlayDie();

        Destroy(gameObject, removingnemy);
    }
}
