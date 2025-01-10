using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private JoysickForMovement _joysickForMovement;
    [SerializeField] private HealthInfo _healthInfoPrefab;
    [SerializeField] private Canvas _healthUi;
    [SerializeField] private AudioSource _takingDamage;
    [SerializeField] private CinemachineImpulseSource _cinemachineImpulseSource;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<JoysickForMovement>()
            .FromInstance(_joysickForMovement)
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<Canvas>()
            .FromInstance(_healthUi)
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<HealthInfo>()
            .FromInstance(_healthInfoPrefab)
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<AudioSource>()
            .FromInstance(_takingDamage)
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<CinemachineImpulseSource>()
            .FromInstance(_cinemachineImpulseSource)
            .AsSingle();
    }
}