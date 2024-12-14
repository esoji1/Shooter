using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class JoystickAttack : BaseJoystickHandler
{
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private WeaponView _weaponView;
 
    private BaseJoystickInfo _joystickInfoAttack;

    public override Image JoystickBackground => _joystickInfoAttack.JoystickBackground;
    public override Image Joystick => _joystickInfoAttack.Joystick;
    public override Image JoystickArea => _joystickInfoAttack.JoystickArea;

    public Vector2 InputVector => _inputVector;

    private void Update()
    {
        _rotateWeapon.JoystickRotationWeapon(_inputVector, _weaponView.GetWeaponView);
    }

    [Inject]
    private void Construct(BaseJoystickInfo joystickInfo)
    {
        _joystickInfoAttack = joystickInfo;
    }
}