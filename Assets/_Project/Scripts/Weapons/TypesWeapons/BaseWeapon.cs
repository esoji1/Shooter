using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IAttackWeapon
{
    private RotateWeapon _rotateWeapon;
    private BaseWeaponView _weaponView;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private WeaponConfig _weaponConfig;
    private AudioSource _audioSourcePrefab;
    private Player _player;

    private Transform _point;

    private List<AudioSource> _audioSources = new();
    private Coroutine _shootCoroutine;

    private SpawnProjectile _spawnProjectile;
    private PlayMusic _playMusic;

    public Transform Point => _point;
    public BaseWeaponView WeaponView => _weaponView;

    public virtual void Initialize(RotateWeapon rotateWeapon, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, WeaponConfig weaponConfig, AudioSource audioSource, Player player)
    {
        _player = player;
        _rotateWeapon = rotateWeapon;

        _point = transform.GetComponentInChildren<PointWeapon>().transform;

        _weaponView = transform.GetComponentInChildren<BaseWeaponView>();
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _weaponConfig = weaponConfig;

        _weaponView.Initialize();
        _spawnProjectile = new SpawnProjectile();

        _audioSourcePrefab = audioSource;
        _playMusic = new PlayMusic();
    }

    public void Attack()
    {
        if (_rotateWeapon.IsAttackJoystickActive && _shootCoroutine == null)
            StartShooting();
        else if (_rotateWeapon.IsAttackJoystickActive == false && _shootCoroutine != null)
            StopShooting();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_weaponConfig.Bullet.Delay);

            GameObject bulletGameObject = _spawnProjectile.ProjectileSpawnPoint(_weaponConfig.Bullet.Projectile, _point);
            Projectile bullet = bulletGameObject.GetComponent<Projectile>();

            AudioSource audioSource = _playMusic.GetAvailableAudioSource(_audioSources, _audioSourcePrefab, transform);
            audioSource.Play();

            bullet.GetComponent<Projectile>().Initialize(_point.right, bullet, _collisionEffect, _bloodEffect,
                _weaponConfig.Bullet, _player.gameObject);
        }
    }

    private void StartShooting()
    {
        _weaponView.StartRecoil();
        _weaponView.StopIdle();

        _shootCoroutine = StartCoroutine(Shoot());
    }

    private void StopShooting()
    {
        _weaponView.StartIdle();
        _weaponView.StopRecoil();

        StopCoroutine(_shootCoroutine);
        _shootCoroutine = null;
    }
}
