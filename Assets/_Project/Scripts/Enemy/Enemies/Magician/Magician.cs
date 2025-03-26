using Assets.Scripts.Enemy;
using UnityEngine;

public class Magician : BaseEnemy, IRangeAttack
{
    private ProjectileConfig _fireballConfig;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;

    private PointAttack _pointAttack;
    private PointHealth _pointHealth;
    private SpawnProjectile _spawnProjectile;

    protected override PointHealth Point => _pointHealth;

    public ProjectileConfig FireballConfig => _fireballConfig;
    public ParticleSystem BloodEffect => _bloodEffect;
    public ParticleSystem CollisionEffect => _collisionEffect;
    public PointAttack GetPointAttack => _pointAttack;
    public SpawnProjectile SpawnProjectile => _spawnProjectile;
    public GameObject GameObject => gameObject;

    protected override void Update() => base.Update();

    public void Initialize(EnemyConfig config, Player target, ParticleSystem bloodEffect,
        ParticleSystem collisionEffect, ProjectileConfig fireballConfig, HealthInfo healthInfo,
        Canvas healthUi, AudioSource takeDomage, Hilka hilka)
    {
        base.Initialize(config, target, healthInfo, healthUi, takeDomage, hilka);

        _fireballConfig = fireballConfig;
        _bloodEffect = bloodEffect;
        _collisionEffect = collisionEffect;
        _spawnProjectile = new SpawnProjectile();

        _pointAttack = transform.GetComponentInChildren<PointAttack>();
        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }
}