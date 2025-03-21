using System;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private BaseEnemy _enemy;

    private Coroutine _coroutine;
    private BaseAttack _attack;

    private void Update()
    {
        if (_enemy.IsDie)
            return;

        ControlAttack();
    }

    public void Initialize(BaseEnemy enemy)
    {
        _enemy = enemy;

        switch (enemy)
        {
            case NormalAttack normalAttack:
                _attack = new MeleeNormalAttack();
                break;

            case HealingAttack healingAttack:
                _attack = new MeleeHealingAttack();
                break;

            case OneShotAttack oneShotAttack:
                _attack = new MeleeOneShotAttack();
                break;

            default:
                throw new ArgumentException($"There is no such type of attack {nameof(enemy)}");
        }
    }

    private void ControlAttack()
    {
        float distance = Vector2.Distance(transform.position, _enemy.GetTarget.position);

        if (distance > _enemy.GetConfig.AttackRadius)
            StopAttackIfNeeded();
        else
            StartAttackIfNeeded();
    }

    private void StopAttackIfNeeded()
    {
        if (_coroutine != null)
        {
            _enemy.GetBaseView.StopAttack();
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAttackIfNeeded()
    {
        if (_coroutine == null)
        {
            _enemy.GetBaseView.StopWalk();
            _coroutine = StartCoroutine(_attack.DelayBeforeAttack(_enemy));
        }
    }
}
