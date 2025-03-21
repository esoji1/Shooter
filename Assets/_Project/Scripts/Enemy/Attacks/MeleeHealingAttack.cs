using System.Collections;
using UnityEngine;

public class MeleeHealingAttack : BaseAttack
{
    public IEnumerator DelayBeforeAttack(BaseEnemy enemy)
    {
        while (true)
        {
            enemy.GetBaseView.StartAttack();

            float attackAnimationTime = enemy.GetBaseView.Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackAnimationTime);

            TryDealDamageToTarget(enemy);
        }
    }

    private void TryDealDamageToTarget(BaseEnemy enemy)
    {
        int healthForHealing = 0;
        int healingFromAttack = 30;

        if (enemy.GetTarget.TryGetComponent(out IDamage damage))
            damage.Damage(enemy.GetConfig.Damage);

        healthForHealing = enemy.GetConfig.Health - healingFromAttack;

        if (enemy.GetHealth.HealthValue <= healthForHealing)
        {
            enemy.GetHealth.AddHealth(healingFromAttack);
            enemy.GetHealthView.AddHealth(healingFromAttack);
        }
    }
}
