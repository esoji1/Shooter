using UnityEngine.UI;
using Zenject;

public class JoystickHandler : BaseJoystickHandler
{
    private BaseJoystickInfo _joystickInfoMovement;

    public override Image JoystickBackground => _joystickInfoMovement.JoystickBackground;
    public override Image Joystick => _joystickInfoMovement.Joystick;
    public override Image JoystickArea => _joystickInfoMovement.JoystickArea;

    [Inject]
    private void Construct(BaseJoystickInfo joystickInfo)
    {
        _joystickInfoMovement = joystickInfo;
    }
}