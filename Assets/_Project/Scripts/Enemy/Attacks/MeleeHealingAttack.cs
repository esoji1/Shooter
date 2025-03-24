using System.Collections;
using UnityEngine;

public class MeleeHealingAttack : BaseAttack
{
    private const float AttackCooldown = 0.2f;

    private LayerMask _layer;
    private BaseEnemy _enemy;
    private Coroutine _coroutine;
    private bool _isAttack;

    public MeleeHealingAttack(BaseEnemy enemy, LayerMask layer)
    {
        _enemy = enemy;
        _layer = layer;
    }

    public void Update()
    {
        if (CheckAttackHit())
            StartAttackIfNeeded();
    }

    private void StopAttackIfNeeded()
    {
        if (_coroutine != null)
        {
            _isAttack = false;
            _enemy.SetMove(true);
            _enemy.GetBaseView.StopAttack();
            _enemy.StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAttackIfNeeded()
    {
        if (_coroutine == null)
        {
            _isAttack = true;
            _enemy.GetBaseView.StopWalk();
            _enemy.SetMove(false);
            _coroutine = _enemy.StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        while (_isAttack && _enemy.IsDie == false)
        {
            if (CheckAttackHit())
            {
                _enemy.GetBaseView.StartAttack();

                float attackAnimationTime = _enemy.GetBaseView.Animator.GetCurrentAnimatorStateInfo(0).length;
                yield return new WaitForSeconds(attackAnimationTime - AttackCooldown);

                if (CheckAttackHit())
                    TryDealDamageToTarget();

                yield return new WaitForSeconds(AttackCooldown);
            }
            else
            {
                StopAttackIfNeeded();
                yield break;
            }
        }
    }

    private bool CheckAttackHit()
    {
        Vector2 direction = _enemy.PointAttack.transform.right;
        RaycastHit2D hit = Physics2D.Raycast(_enemy.PointAttack.transform.position, direction, _enemy.GetConfig.RaycastAttack, _layer);

        return hit.collider != null && hit.collider.TryGetComponent(out Player _);
    }

    private void TryDealDamageToTarget()
    {
        int healthForHealing = 0;
        int healingFromAttack = 30;

        if (_enemy.GetTarget.TryGetComponent(out IDamage damage))
            damage.Damage(_enemy.GetConfig.Damage);

        healthForHealing = _enemy.GetConfig.Health - healingFromAttack;

        if (_enemy.GetHealth.HealthValue <= healthForHealing)
        {
            _enemy.GetHealth.AddHealth(healingFromAttack);
            _enemy.GetHealthView.AddHealth(healingFromAttack);
        }
    }
}
