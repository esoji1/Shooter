using Assets.Scripts.Weapon.Bullet;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10f;
    private Vector2 _direction;
    private GameObject _bullet;
    private ParticleSystem _collisionEffect;

    private RemoveBullet _removeBullet;

    private void Awake()
    {
        _removeBullet = new RemoveBullet();
    }

    private void Update()
    {
        _removeBullet.RemoveTimePasses(_bullet);

        GiveBulletAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _removeBullet.RemovalUponCollisionWall(collision, _bullet, _collisionEffect);
    }

    public void Initialize(Vector2 direction, GameObject bullet, ParticleSystem collisionEffect)
    {
        _direction = direction.normalized;
        _bullet = bullet;
        _collisionEffect = collisionEffect;
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