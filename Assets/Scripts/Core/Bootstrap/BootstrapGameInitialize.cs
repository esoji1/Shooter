using UnityEngine;

public class BootstrapGameInitialize : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BootstrapEnemyFactory _bootstrapEnemyFactory;
    [SerializeField] private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    [SerializeField] private BootstrapWeaponKalash _bootstrapWeaponKalash;

    private void Awake()
    {
        _player.Initialize();
        _bootstrapEnemyFactory.Initialize();

        _bootstrapEnemyWaveSpawner.Initialize();
        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.StartEnemyWaveSpawner();

        _bootstrapWeaponKalash.Initialize();
    }
}
