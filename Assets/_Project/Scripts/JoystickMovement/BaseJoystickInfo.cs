using UnityEngine;
using UnityEngine.UI;

public abstract class BaseJoystickInfo : MonoBehaviour
{
    public abstract Image JoystickBackground { get; }
    public abstract Image Joystick { get; }
    public abstract Image JoystickArea { get; }
}