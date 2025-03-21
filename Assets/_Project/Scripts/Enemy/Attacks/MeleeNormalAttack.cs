using System.Collections;
using UnityEngine;

public class MeleeNormalAttack : BaseAttack
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
        if (enemy.GetTarget.TryGetComponent(out IDamage damage))
            damage.Damage(enemy.GetConfig.Damage);
    }
}
