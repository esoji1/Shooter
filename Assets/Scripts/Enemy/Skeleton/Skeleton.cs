using Assets.Scripts.Enemy;

public class Skeleton : BaseEnemy
{
    public override void Initialize(EnemyConfig config, Player target)
    {
        base.Initialize(config, target);
    }

    protected override void TryDealDamageToTarget()
    {
        if (Target.TryGetComponent(out IDamage damage))
            damage.Damage(Config.Damage);
    }
}