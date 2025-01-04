using UnityEngine;
using Zenject;

public class JoystickHandlerInstaller : MonoInstaller
{
    [SerializeField] private JoystickInfoMovement _joystickInfoMovement;

    public override void InstallBindings()
    {
        BindJoystickInfo();
    }

    private void BindJoystickInfo()
    {
        Container
            .Bind<BaseJoystickInfo>()
            .FromInstance(_joystickInfoMovement)
            .WhenInjectedInto<JoystickHandler>();
    }
}