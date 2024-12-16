using System.Collections;
using UnityEngine;

public class WeaponKalash : MonoBehaviour
{
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _point;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private ParticleSystem _bloodEffect;

    private Coroutine _shootCoroutine;
    private float _delay = 0.1f;

    public Transform Point => _point;

    private void Awake()
    {
        _weaponView.Initialize();
    }

    private void Update()
    {
        StartSterling();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bulletObject = BulletSpawnPoint();
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.Initialize(_point.right, bulletObject, _collisionEffect, _bloodEffect);
            yield return new WaitForSeconds(_delay);
        }
    }

    private GameObject BulletSpawnPoint()
    {
        GameObject bullet = Instantiate(_prefabBullet, _point.position, Quaternion.identity, null);

        Vector3 direction = _point.right;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        return bullet;
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
