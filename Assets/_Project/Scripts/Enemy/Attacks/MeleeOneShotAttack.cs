using Assets.Scripts.Enemy;
using UnityEngine;

public class MeleeOneShotAttack : IBaseAttack
{
    private BaseEnemy _enemy;

    public MeleeOneShotAttack(BaseEnemy enemy) => _enemy = enemy;

    public void Update()
    {
        if (_enemy.IsDie)
            return;

        float distance = Vector2.Distance(_enemy.transform.position, _enemy.GetTarget.position);

        if (distance < _enemy.GetConfig.AttackRadius)
            TryDealDamageToTarget();

    }

    private void TryDealDamageToTarget()
    {
        if (_enemy.GetTarget.TryGetComponent(out IDamage damage))
            damage.Damage(_enemy.GetConfig.Damage);

        _enemy.Damage(_enemy.GetConfig.Health);
    }
}
