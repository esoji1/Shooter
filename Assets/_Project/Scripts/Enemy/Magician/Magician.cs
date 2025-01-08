using UnityEngine;

public class Magician : BaseEnemy
{
    private ProjectileConfig _fireballConfig;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;

    private PointAttack _pointAttack;
    private PointHealth _pointHealth;
    private SpawnProjectile _spawnProjectile;

    protected override PointHealth Point => _pointHealth;

    protected override void Update()
    {
        base.Update();

        FlipPointAttack(Direction);
    }

    public void Initialize(EnemyConfig config, Player target, ParticleSystem bloodEffect,
        ParticleSystem collisionEffect, ProjectileConfig fireballConfig, HealthInfo healthInfo,
        Canvas healthUi)
    {
        base.Initialize(config, target, healthInfo, healthUi);

        _fireballConfig = fireballConfig;
        _bloodEffect = bloodEffect;
        _collisionEffect = collisionEffect;
        _spawnProjectile = new SpawnProjectile();

        _pointAttack = transform.GetComponentInChildren<PointAttack>();
        _pointHealth = gameObject.GetComponentInChildren<PointHealth>();
    }

    protected override void TryDealDamageToTarget()
    {
        GameObject magicianGameObject = _spawnProjectile.ProjectileSpawnPoint(_fireballConfig.Projectile, _pointAttack.transform);
        Projectile fireball = magicianGameObject.GetComponent<Projectile>();
        fireball.Initialize(Direction.normalized, fireball, _collisionEffect, _bloodEffect, _fireballConfig, gameObject);
    }

    protected void FlipPointAttack(Vector2 inputVector)
    {
        if (inputVector.x < 0f)
            _pointAttack.transform.localPosition = new Vector2(_pointAttack.transform.localPosition.x, 0.078f);
        else if (inputVector.x > 0f)
            _pointAttack.transform.localPosition = new Vector2(_pointAttack.transform.localPosition.x, -0.066f);
    }
}