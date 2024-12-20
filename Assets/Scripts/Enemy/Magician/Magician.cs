using UnityEngine;
using static UnityEngine.Rendering.STP;

public class Magician : BaseEnemy
{
    private ProjectileConfig _fireballConfig;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;
    private Fireball _fireball;

    private PointAttack _pointAttack;
    private SpawnProjectile _spawnProjectile;

    protected override void Update()
    {
        base.Update();

        FlipPointAttack(Direction);
    }

    public void Initialize(EnemyConfig config, Player target, ParticleSystem bloodEffect,
        Fireball fireball, ParticleSystem collisionEffect, ProjectileConfig fireballConfig)
    {
        base.Initialize(config, target);

        _fireballConfig = fireballConfig;
        _bloodEffect = bloodEffect;
        _fireball = fireball;
        _collisionEffect = collisionEffect;
        _spawnProjectile = new SpawnProjectile();

        _pointAttack = transform.GetComponentInChildren<PointAttack>();
    }

    protected override void TryDealDamageToTarget()
    {
        GameObject magicianGameObject = _spawnProjectile.ProjectileSpawnPoint(_fireball.gameObject, _pointAttack.transform);
        Fireball fireball = magicianGameObject.GetComponent<Fireball>();
        fireball.Initialize(Direction.normalized, fireball, _bloodEffect, _collisionEffect, _fireballConfig);
    }

    protected void FlipPointAttack(Vector2 inputVector)
    {
        if (inputVector.x < 0f)
            _pointAttack.transform.localPosition = new Vector2(_pointAttack.transform.localPosition.x, 0.078f);
        else if (inputVector.x > 0f)
            _pointAttack.transform.localPosition = new Vector2(_pointAttack.transform.localPosition.x, -0.066f);
    }
}