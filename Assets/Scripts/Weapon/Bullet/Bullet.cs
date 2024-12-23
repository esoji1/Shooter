using Assets.Scripts.Weapon.Bullet;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ProjectileConfig _fireballConfig;
    private Bullet _bullet;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private Vector2 _direction;

    private RemoveBullet _removeBullet;
    private DealDamage _dealDamage;

    private void Update()
    {
        _removeBullet.RemoveTimePasses(_bullet.gameObject, _fireballConfig.NumberSecondsBeforeRemoval);

        GiveBulletAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _removeBullet.RemovalUponCollisionWall(collision, _bullet.gameObject, _collisionEffect);

        _dealDamage.Damage(collision, _fireballConfig.Damage, _bullet.gameObject, _bloodEffect);
    }

    public void Initialize(Vector2 direction, Bullet bullet, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, ProjectileConfig fireballConfig)
    {
        _direction = direction.normalized;
        _bullet = bullet;
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _fireballConfig = fireballConfig;

        _removeBullet = new RemoveBullet();
        _dealDamage = new DealDamage();
    }

    private void GiveBulletAcceleration()
    {
        if (_direction != Vector2.zero)
            TranslateBullet();
    }

    private void TranslateBullet() => transform.Translate(_direction * _fireballConfig.Speed * Time.deltaTime, Space.World);
}