using Assets.Scripts.Enemy;
using UnityEngine;

public class Robot : BaseEnemy
{
    private PointHealth _pointHealth;

    protected override PointHealth Point => _pointHealth;

    public override void Initialize(EnemyConfig config, Player target, HealthInfo healthInfo,
        Canvas healthUi, AudioSource takeDomage)
    {
        base.Initialize(config, target, healthInfo, healthUi, takeDomage);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    protected override void TryDealDamageToTarget()
    {
        int healthForHealing = 0;
        int healingFromAttack = 30;

        if (Target.TryGetComponent(out IDamage damage))
            damage.Damage(Config.Damage);

        healthForHealing = Config.Health - healingFromAttack;

        if (Health.HealthValue <= healthForHealing)
        {
            Health.AddHealth(healingFromAttack);
            HealthView.AddHealth(healingFromAttack);
        }
    }
}
