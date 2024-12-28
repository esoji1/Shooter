using System;
using UnityEngine;

public class BootstrapWeapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private WeaponConfig _emkaConfig, _kalashConfig;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private JoystickAttack _joystickAttack;

    private WeaponFactory _weaponFactory;

    public event Action<BaseWeapon> OnSpawnWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BaseWeapon weapon = _weaponFactory.Get(WeaponTypes.Emka, transform.position);
            OnSpawnWeapon?.Invoke(weapon);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            BaseWeapon weapon = _weaponFactory.Get(WeaponTypes.Kalash, transform.position);
            OnSpawnWeapon?.Invoke(weapon);
        }
    }

    public void Initialize()
    {
        _weaponFactory = new WeaponFactory(_joystickAttack.RotateWeapon, _bullet, _collisionEffect,
            _bloodEffect, _kalashConfig, _emkaConfig, _audioSource);
    }
}
