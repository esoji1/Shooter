using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class JoystickAttack : BaseJoystickHandler
{
    //[SerializeField] private BootstrapWeapon _weapon;
    [SerializeField] private Transform _weaponPosition;

    private RotateWeapon _rotateWeapon;
    private BaseJoystickInfo _joystickInfoAttack;

    private List<BaseWeapon> _weapons = new();

    public override Image JoystickBackground => _joystickInfoAttack.JoystickBackground;
    public override Image Joystick => _joystickInfoAttack.Joystick;
    public override Image JoystickArea => _joystickInfoAttack.JoystickArea;
    public RotateWeapon RotateWeapon => _rotateWeapon;
    
    private void Update()
    {
        _rotateWeapon.JoystickRotationWeapon(_inputVector);
    }

    public void Initialize()
    {
        _rotateWeapon = new RotateWeapon(_weaponPosition);

        //_weapon.OnSpawnWeapon += AddWeapon;
    }

    [Inject]
    private void Construct(BaseJoystickInfo joystickInfo)
    {
        _joystickInfoAttack = joystickInfo;
    }

    private void AddWeapon(BaseWeapon weapon) 
        => _weapons.Add(weapon);
}