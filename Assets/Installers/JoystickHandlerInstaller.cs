using UnityEngine;
using Zenject;

public class JoystickHandlerInstaller : MonoInstaller
{
    [SerializeField] private JoystickInfo _joystickInfo;

    public override void InstallBindings()
    {
        BindJoystickInfo();
    }

    private void BindJoystickInfo()
    {
        Container
             .Bind<JoystickInfo>()
             .FromInstance(_joystickInfo)
             .AsSingle();
    }
}