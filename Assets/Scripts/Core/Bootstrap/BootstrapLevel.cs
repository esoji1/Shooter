using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLevel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BootstrapEnemyFactory _bootstrapEnemyFactory;
    [SerializeField] private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    [SerializeField] private BootstrapWeaponKalash _bootstrapWeaponKalash;
    [SerializeField] private BootstrapGameplayMediator GameplayMediator;

    public Player Player => _player;

    private void Awake()
    {
        _player.Initialize();
        _bootstrapEnemyFactory.Initialize();

        _bootstrapEnemyWaveSpawner.Initialize();
        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.StartEnemyWaveSpawner();

        _bootstrapWeaponKalash.Initialize();
        GameplayMediator.Initialie();
    }

    public void RestartLevel() 
        => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
