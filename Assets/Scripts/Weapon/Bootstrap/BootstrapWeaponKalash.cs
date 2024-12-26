using UnityEngine;

public class BootstrapWeaponKalash : MonoBehaviour
{
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _point;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private ProjectileConfig _bulletConfig;
    [SerializeField] private WeaponKalash _weaponKalash;
    [SerializeField] private AudioSource _audioSource;

    public void Initialize()
    {
        _weaponKalash.Initialize(_rotateWeapon, _bullet, _point, _weaponView,
            _collisionEffect, _bloodEffect, _bulletConfig, _audioSource);
    }
}
