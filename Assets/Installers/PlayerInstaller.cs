using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private JoysickForMovement _joysickForMovement;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<JoysickForMovement>()
            .FromInstance(_joysickForMovement)
            .AsSingle();
    }
}