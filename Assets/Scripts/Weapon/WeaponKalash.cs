using System.Collections;
using System.Collections.Generic;
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
    private AudioSource _audioSourcePrefab;

    private List<AudioSource> _audioSources = new();
    private Coroutine _shootCoroutine;
    private float _delay = 0.1f;

    private SpawnProjectile _spawnProjectile;

    public Transform Point => _point;

    private void Update()
    {
        StartSterling();
    }

    public void Initialize(RotateWeapon rotateWeapon, Bullet bullet, Transform point, WeaponView weaponView,
        ParticleSystem collisionEffect, ParticleSystem bloodEffect, ProjectileConfig bulletConfig, AudioSource audioSource)
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

        _audioSourcePrefab = audioSource;
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bulletGameObject = _spawnProjectile.ProjectileSpawnPoint(_bullet.gameObject, _point);
            Bullet bullet = bulletGameObject.GetComponent<Bullet>();

            AudioSource audioSource = GetAvailableAudioSource();
            audioSource.Play();

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

    private AudioSource GetAvailableAudioSource()
    {
        foreach (AudioSource source in _audioSources)
            if (source.isPlaying == false)
                return source;

        AudioSource newSource = Instantiate(_audioSourcePrefab, transform);
        _audioSources.Add(newSource);
        return newSource;
    }
}
