using Assets.Scripts.Weapon.Bullet;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10f;
    private Vector2 _direction;
    private GameObject _bullet;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
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

        _dealDamage.Damage(collision, _damage, _bullet, _bloodEffect);
    }

    public void Initialize(Vector2 direction, GameObject bullet, ParticleSystem collisionEffect, ParticleSystem bloodEffect)
    {
        _direction = direction.normalized;
        _bullet = bullet;
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
    }

    private void TranslateBullet()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void GiveBulletAcceleration()
    {
        if (_direction != Vector2.zero)
        {
            TranslateBullet();
        }
    }
}