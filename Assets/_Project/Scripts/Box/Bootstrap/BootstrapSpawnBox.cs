using UnityEngine;

public class BootstrapSpawnBox : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
    [SerializeField] private BootstrapWeaponFactory _weaponFactory;
    [SerializeField] private SpawnBox _spawnBox;
    [SerializeField] private BootstraTakeAwayWeapon _takeAwayWeapon;
    [SerializeField] private PointBox _pointBox;

    public SpawnBox SpawnBox => _spawnBox;

    private void Awake()
    {
        _spawnBox.Initialize(_box, _enemyWaveSpawner, _weaponFactory.WeaponFactory, _takeAwayWeapon, _pointBox);
        _spawnBox.FirtSpawnBox();
    }
}
