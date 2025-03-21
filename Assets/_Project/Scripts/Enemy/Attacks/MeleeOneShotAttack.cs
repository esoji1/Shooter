using System.Collections;

public class MeleeOneShotAttack : BaseAttack
{
    public IEnumerator DelayBeforeAttack(BaseEnemy enemy)
    {
        TryDealDamageToTarget(enemy);
        yield return null;
    }

    private void TryDealDamageToTarget(BaseEnemy enemy)
    {
        if (enemy.GetTarget.TryGetComponent(out IDamage damage))
            damage.Damage(enemy.GetConfig.Damage);

        enemy.Damage(enemy.GetConfig.Health);
    }
}
