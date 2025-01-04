using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLevel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BootstrapEnemyFactory _bootstrapEnemyFactory;
    [SerializeField] private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    [SerializeField] private BootstrapWeaponFactory _bootstrapWeaponFactory;
    [SerializeField] private BootstrapGameplayMediator GameplayMediator;
    [SerializeField] private BootstraTakeAwayWeapon _bootstraTakeAwayWeapon;
    [SerializeField] private JoystickAttack _joystickAttack;
    [SerializeField] private BootstrapSpawnBox _bootstrapSpawnBox;
    [SerializeField] private BootstrapVictory _bootstrapVictory;

    public Player Player => _player;
    
    private void Awake()
    {
        Time.timeScale = 1;

        _joystickAttack.Initialize();

        _player.Initialize();
        _bootstrapEnemyFactory.Initialize();

        _bootstrapEnemyWaveSpawner.Initialize();
        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.StartEnemyWaveSpawner();

        _bootstraTakeAwayWeapon.Initialize();
        _bootstrapWeaponFactory.Initialize();
        GameplayMediator.Initialie();

        _bootstrapSpawnBox.Initialize();
        _bootstrapSpawnBox.SpawnBox.FirtSpawnBox();

        _bootstrapVictory.Initialize();
    }

    public void RestartLevel() 
        => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void StopGame()
        => Time.timeScale = 0;
}
