using Assets.Scripts.Weapon.Bullet;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private ProjectileConfig _fireballConfig;
    private Fireball _fireball;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;
    private Vector2 _direction;

    private RemoveBullet _removeBullet;
    private DealDamage _dealDamage;

    private void Awake()
    {
        _removeBullet = new RemoveBullet();
        _dealDamage = new DealDamage();
    }

    private void Update()
    {
        _removeBullet.RemoveTimePasses(_fireball.gameObject, _fireballConfig.NumberSecondsBeforeRemoval);

        GiveBulletAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _removeBullet.RemovalUponCollisionWall(collision, _fireball.gameObject, _collisionEffect);

        if (collision.TryGetComponent(out Player player))
            _dealDamage.Damage(collision, _fireballConfig.Damage, _fireball.gameObject, _bloodEffect);
    }

    public void Initialize(Vector2 direction, Fireball fireball, ParticleSystem bloodEffect,
        ParticleSystem collisionEffect, ProjectileConfig fireballConfig)
    {
        _direction = direction.normalized;
        _fireball = fireball;
        _bloodEffect = bloodEffect;
        _collisionEffect = collisionEffect;
        _fireballConfig = fireballConfig;
    }

    private void GiveBulletAcceleration()
    {
        if (_direction != Vector2.zero)
            TranslateBullet();
    }

    private void TranslateBullet() => transform.Translate(_direction * _fireballConfig.Speed * Time.deltaTime, Space.World);
}
