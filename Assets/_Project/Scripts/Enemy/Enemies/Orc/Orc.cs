using UnityEngine;

public class Orc : BaseEnemy, NormalAttack
{
    private PointHealth _pointHealth;

    protected override PointHealth Point => _pointHealth;

    public override void Initialize(EnemyConfig config, Player target, HealthInfo healthInfo,
        Canvas healthUi, AudioSource takeDomage, Hilka hilka)
    {
        base.Initialize(config, target, healthInfo, healthUi, takeDomage, hilka);

        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }
}
