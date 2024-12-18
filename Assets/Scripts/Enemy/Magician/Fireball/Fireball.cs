using Assets.Scripts.Weapon.Bullet;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float _speed = 5f;
    private Vector2 _direction;
    private GameObject _bullet;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;
    private int _damage = 5;

    private RemoveBullet _removeBullet;
    private DealDamage _dealDamage;

    private void Awake()
    {
        _removeBullet = new RemoveBullet();
        _dealDamage = new DealDamage();
    }

    private void Update()
    {
        _removeBullet.RemoveTimePasses(_bullet);

        GiveBulletAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _removeBullet.RemovalUponCollisionWall(collision, _bullet, _collisionEffect);

        if (collision.TryGetComponent(out Player player))
            _dealDamage.Damage(collision, _damage, _bullet, _bloodEffect);
    }

    public void Initialize(Vector2 direction, GameObject bullet, ParticleSystem bloodEffect, ParticleSystem collisionEffect)
    {
        _direction = direction.normalized;
        _bullet = bullet;
        _bloodEffect = bloodEffect;
        _collisionEffect = collisionEffect;
    }

    private void GiveBulletAcceleration()
    {
        if (_direction != Vector2.zero)
        {
            TranslateBullet();
        }
    }

    private void TranslateBullet()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
}
