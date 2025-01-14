using UnityEngine.UI;
using Zenject;

public class JoystickAttack : BaseJoystickHandler
{
    private RotateWeapon _rotateWeapon;
    private BaseJoystickInfo _joystickInfoAttack;
    private WeaponPosition _weaponPosition;

    public override Image JoystickBackground => _joystickInfoAttack.JoystickBackground;
    public override Image Joystick => _joystickInfoAttack.Joystick;
    public override Image JoystickArea => _joystickInfoAttack.JoystickArea;
    public RotateWeapon RotateWeapon => _rotateWeapon;
    
    public void Initialize() 
        => _rotateWeapon = new RotateWeapon(_weaponPosition);

    private void Update() 
        => _rotateWeapon.JoystickRotationWeapon(_inputVector);

    [Inject]
    private void Construct(BaseJoystickInfo joystickInfo, WeaponPosition weaponPosition)
    {
        _joystickInfoAttack = joystickInfo;
        _weaponPosition = weaponPosition;
    }
}