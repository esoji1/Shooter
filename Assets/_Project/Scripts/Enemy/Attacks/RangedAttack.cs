using Assets.Scripts.Enemy;
using System.Collections;
using UnityEngine;

public class RangedAttack : IBaseAttack
{
    private BaseEnemy _enemy;
    private IRangeAttack _rangeAttack;
    private Coroutine _coroutine;

    public RangedAttack(BaseEnemy enemy)
    {
        _enemy = enemy;
        _rangeAttack = _enemy as IRangeAttack;
    }

    public void Update()
    {
        float distance = Vector2.Distance(_enemy.transform.position, _enemy.GetTarget.position);

        if (distance < _enemy.GetConfig.AttackRadius)
            StartAttackIfNeeded();
        else
            StopAttackIfNeeded();

        FlipPointAttack(_enemy.Direction);
    }

    private void StopAttackIfNeeded()
    {
        if (_coroutine != null)
        {
            _enemy.GetBaseView.StopAttack();
            _enemy.StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAttackIfNeeded()
    {
        if (_coroutine == null)
        {
            _enemy.GetBaseView.StopWalk();
            _coroutine = _enemy.StartCoroutine(DelayBeforeAttack());
        }
    }

    private IEnumerator DelayBeforeAttack()
    {
        while (_enemy.IsDie == false)
        {
            _enemy.GetBaseView.StartAttack();

            float attackAnimationTime = _enemy.GetBaseView.Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackAnimationTime);

            TryDealDamageToTarget();
        }
    }

    protected void TryDealDamageToTarget()
    {
        GameObject magicianGameObject = _rangeAttack.SpawnProjectile.ProjectileSpawnPoint(_rangeAttack.FireballConfig.Projectile, _rangeAttack.GetPointAttack.transform);
        Projectile fireball = magicianGameObject.GetComponent<Projectile>();
        fireball.Initialize(_enemy.Direction.normalized, fireball, _rangeAttack.CollisionEffect, _rangeAttack.BloodEffect, _rangeAttack.FireballConfig, _rangeAttack.GameObject, 
            (Collider2D collison) => collison.TryGetComponent(out Magician _));
    }

    private void FlipPointAttack(Vector2 inputVector)
    {
        if (inputVector.x < 0f)
            _rangeAttack.GetPointAttack.transform.localPosition = new Vector2(_rangeAttack.GetPointAttack.transform.localPosition.x, 0.078f);
        else if (inputVector.x > 0f)
            _rangeAttack.GetPointAttack.transform.localPosition = new Vector2(_rangeAttack.GetPointAttack.transform.localPosition.x, -0.066f);
    }
}
