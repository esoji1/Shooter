using UnityEngine;
using UnityEngine.UI;

public class JoystickInfo : MonoBehaviour
{
    [SerializeField] private Image _joystickBackground;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickArea;

    public Image JoystickBackground => _joystickBackground;
    public Image Joystick => _joystick;
    public Image JoystickArea => _joystickArea;
}