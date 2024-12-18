using Assets.Scripts.Enemy;
using System.Collections;
using UnityEngine;

public class Magician : MonoBehaviour, IDamage
{
    private EnemyConfig _config;
    private Player _target;
    private MagicianView _magicianView;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;
    private GameObject _fireball;

    private bool _isDie = false;
    private Vector2 _direction;

    private Coroutine _coroutine;
    private BoxCollider2D _boxCollider2D;

    private Health _health;
    private ChangeEnemyPosition _changeEnemyPosition;
    private Flip _flip;
    private PointAttack _pointAttack;

    private void Awake()
    {
        _health = new Health(100);
        _changeEnemyPosition = new ChangeEnemyPosition();
        _flip = new Flip();
    }

    private void Start()
    {
        _magicianView.Initialize();
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

    public void Initialize(EnemyConfig config, Player target, ParticleSystem bloodEffect, GameObject fireball, ParticleSystem collisionEffect)
    {
        _config = config;
        _target = target;
        _bloodEffect = bloodEffect;
        _fireball = fireball;
        _collisionEffect = collisionEffect;

        _magicianView = transform.GetComponentInChildren<MagicianView>();
        _pointAttack = transform.GetComponentInChildren<PointAttack>();
    }

    public void Damage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void HandleMovementAndAttack()
    {
        float distance = Vector2.Distance(transform.position, _target.transform.position);
        _direction = (_target.transform.position - transform.position).normalized;

        _flip.FlipSpriteY(_direction, _magicianView.SpriteRenderer);
        FlipPointAttack(_direction);

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
        _magicianView.StopAttack();
        _magicianView.StartWalk();

        Vector3 targetPosition = _target.transform.position + _changeEnemyPosition.AddRandomPositionToGo;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _config.Speed * Time.deltaTime);
    }

    private void StopAttackIfNeeded()
    {
        if (_coroutine != null)
        {
            _magicianView.StopAttack();
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAttackIfNeeded()
    {
        if (_coroutine == null)
        {
            _magicianView.StopWalk();
            _coroutine = StartCoroutine(DelayBeforeAttack());
        }
    }

    private IEnumerator DelayBeforeAttack()
    {
        while (true)
        {
            _magicianView.StartAttack();

            float attackAnimationTime = _magicianView.Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackAnimationTime);

            TryDealDamageToTarget();
        }
    }

    private void TryDealDamageToTarget()
    {
        GameObject magician = BulletSpawnPoint();
        magician.GetComponent<Fireball>().Initialize(_direction.normalized, magician, _bloodEffect, _collisionEffect);
    }

    private GameObject BulletSpawnPoint()
    {
        GameObject bullet = Instantiate(_fireball, _pointAttack.transform.position, Quaternion.identity, null);

        Vector3 direction = _pointAttack.transform.right;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        return bullet;
    }

    private void Die()
    {
        StopAttackIfNeeded();

        float removingnemy = 5f;

        _isDie = true;
        _boxCollider2D.enabled = false;

        _magicianView.PlayDie();

        Destroy(gameObject, removingnemy);
    }

    private void FlipPointAttack(Vector2 inputVector)
    {
        if (inputVector.x < 0f)
        {
            _pointAttack.transform.localPosition = new Vector2(_pointAttack.transform.localPosition.x, 0.078f);
        }
        else if (inputVector.x > 0f)
        {
            _pointAttack.transform.localPosition = new Vector2(_pointAttack.transform.localPosition.x, -0.066f);
        }
    }
}
