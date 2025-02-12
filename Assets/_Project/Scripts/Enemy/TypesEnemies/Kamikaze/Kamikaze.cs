using Assets.Scripts.Enemy;
using System.Collections;
using UnityEngine;

public class Kamikaze : BaseEnemy
{
    private PointHealth _pointHealth;

    protected override PointHealth Point => _pointHealth;

    public override void Initialize(EnemyConfig config, Player target, HealthInfo healthInfo,
        Canvas healthUi, AudioSource takeDomage, Hilka hilka)
    {
        base.Initialize(config, target, healthInfo, healthUi, takeDomage, hilka);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    protected override void TryDealDamageToTarget()
    {
        if (Target.TryGetComponent(out IDamage damage))
            damage.Damage(Config.Damage);

        Damage(Config.Health);
    }

    protected override IEnumerator DelayBeforeAttack()
    {
        TryDealDamageToTarget();
        yield return null;
    }
}