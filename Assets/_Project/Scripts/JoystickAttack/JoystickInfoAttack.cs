using UnityEngine;
using UnityEngine.UI;

public class JoystickInfoAttack : BaseJoystickInfo
{
    [SerializeField] private Image _joystickBackgroundAttack;
    [SerializeField] private Image _joystickAttack;
    [SerializeField] private Image _joystickAreaAttack;

    public override Image JoystickBackground => _joystickBackgroundAttack;
    public override Image Joystick => _joystickAttack;
    public override Image JoystickArea => _joystickAreaAttack;
}