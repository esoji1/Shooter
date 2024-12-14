using UnityEngine;
using UnityEngine.UI;

public class JoystickInfoMovement : BaseJoystickInfo
{
    [SerializeField] private Image _joystickBackground;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickArea;

    public override Image JoystickBackground => _joystickBackground;
    public override Image Joystick => _joystick;
    public override Image JoystickArea => _joystickArea;
}