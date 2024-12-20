using System.Collections;
using UnityEngine;

public class WeaponKalash : MonoBehaviour
{
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _point;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private ProjectileConfig _bulletConfig;

    private Coroutine _shootCoroutine;
    private float _delay = 0.1f;

    private SpawnProjectile _spawnProjectile;

    public Transform Point => _point;

    private void Awake()
    {
        _weaponView.Initialize();
        _spawnProjectile = new SpawnProjectile();
    }

    private void Update()
    {
        StartSterling();
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
