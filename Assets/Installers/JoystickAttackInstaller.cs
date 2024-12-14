using UnityEngine;
using Zenject;

public class JoystickAttackInstaller : MonoInstaller
{
    [SerializeField] private JoystickInfoAttack _joystickInfoAttack;

    public override void InstallBindings()
    {
        BindJoystickAttackInfo();
    }

    private void BindJoystickAttackInfo()
    {
        Container
             .Bind<BaseJoystickInfo>()
             .FromInstance(_joystickInfoAttack)
             .WhenInjectedInto<JoystickAttack>();
    }
}