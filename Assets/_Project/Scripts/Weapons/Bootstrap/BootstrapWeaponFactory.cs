using UnityEngine;

public class BootstrapWeaponFactory : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private WeaponConfig _emkaConfig, _kalashConfig, _gunConfig, _sniperConfig, _submachineConfig;
    [SerializeField] private Player _player;

    private WeaponFactory _weaponFactory;

    public WeaponFactory WeaponFactory => _weaponFactory;

    public void Initialize(JoystickAttack joystickAttack) 
        => _weaponFactory = new WeaponFactory(joystickAttack.RotateWeapon, _collisionEffect,
            _bloodEffect, _kalashConfig, _emkaConfig, _gunConfig, _sniperConfig, _submachineConfig, _player);
}
