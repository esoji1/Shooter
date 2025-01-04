using UnityEngine;
using Zenject;

public class JoysickForMovementInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerView _playerView;

    public override void InstallBindings()
    {
        BindJoysickForMovement();
    }

    private void BindJoysickForMovement()
    {
        Container
            .Bind<PlayerMovement>()
            .FromInstance(_playerMovement)
            .AsSingle();

        Container
            .Bind<PlayerView>()
            .FromInstance(_playerView)
            .AsSingle();
    }
}