using Assets.Scripts.Weapon.Bullet;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectileConfig _bulletConfig;
    private Projectile _projectile;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private Vector2 _direction;
    private GameObject _owner;

    private RemoveBullet _removeBullet;
    private DealDamage _dealDamage;

    private void Update()
    {
        _removeBullet.RemoveTimePasses(_projectile.gameObject, _bulletConfig.NumberSecondsBeforeRemoval);

        GiveBulletAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _removeBullet.RemovalUponCollisionWall(collision, _projectile.gameObject, _collisionEffect);

        _dealDamage.Damage(collision, _bulletConfig.Damage, _projectile.gameObject, _bloodEffect, _owner);
    }

    public void Initialize(Vector2 direction, Projectile projectile, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, ProjectileConfig fireballConfig, GameObject owner)
    {
        _direction = direction.normalized;
        _projectile = projectile;
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _bulletConfig = fireballConfig;
        _owner = owner;

        _removeBullet = new RemoveBullet();
        _dealDamage = new DealDamage();
    }

    private void GiveBulletAcceleration()
    {
        if (_direction != Vector2.zero)
            TranslateBullet();
    }

    private void TranslateBullet() => transform.Translate(_direction * _bulletConfig.Speed * Time.deltaTime, Space.World);
}