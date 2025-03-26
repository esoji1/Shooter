using Assets.Scripts.Enemy;
using UnityEngine;

public class Kamikaze : BaseEnemy, IOneShotAttack
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