using System;
using UnityEngine;

public class BootstrapWeaponFactory : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private WeaponConfig _emkaConfig, _kalashConfig;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private JoystickAttack _joystickAttack;

    private WeaponFactory _weaponFactory;

    public WeaponFactory WeaponFactory => _weaponFactory;

    public void Initialize()
    {
        _weaponFactory = new WeaponFactory(_joystickAttack.RotateWeapon, _bullet, _collisionEffect,
            _bloodEffect, _kalashConfig, _emkaConfig, _audioSource);
    }
}
