using System.Collections;
using UnityEngine;

public class WeaponKalash : MonoBehaviour
{
    private RotateWeapon _rotateWeapon;
    private Bullet _bullet;
    private Transform _point;
    private WeaponView _weaponView;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private ProjectileConfig _bulletConfig;

    private Coroutine _shootCoroutine;
    private float _delay = 0.1f;

    private SpawnProjectile _spawnProjectile;

    public Transform Point => _point;

    private void Update()
    {
        StartSterling();
    }

    public void Initialize(RotateWeapon rotateWeapon, Bullet bullet, Transform point, WeaponView weaponView,
        ParticleSystem collisionEffect, ParticleSystem bloodEffect, ProjectileConfig bulletConfig)
    {
        _rotateWeapon = rotateWeapon;
        _bullet = bullet;
        _point = point;
        _weaponView = weaponView;
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _bulletConfig = bulletConfig;

        _weaponView.Initialize();
        _spawnProjectile = new SpawnProjectile();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bulletGameObject = _spawnProjectile.ProjectileSpawnPoint(_bullet.gameObject, _point);
            Bullet bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.GetComponent<Bullet>().Initialize(_point.right, bullet, _collisionEffect, _bloodEffect, _bulletConfig);
            yield return new WaitForSeconds(_delay);
        }
    }

    private void StartSterling()
    {
        if (_rotateWeapon.IsAttackJoystickActive && _shootCoroutine == null)
        {
            _weaponView.StartRecoil();
            _weaponView.StopIdle();

            _shootCoroutine = StartCoroutine(Shoot());
        }
        else if (_rotateWeapon.IsAttackJoystickActive == false && _shootCoroutine != null)
        {
            _weaponView.StartIdle();
            _weaponView.StopRecoil();

            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }
}
