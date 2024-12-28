using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLevel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BootstrapEnemyFactory _bootstrapEnemyFactory;
    [SerializeField] private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    [SerializeField] private BootstrapWeapon _bootstrapWeapon;
    [SerializeField] private BootstrapGameplayMediator GameplayMediator;
    [SerializeField] private BootstraTakeAwayWeapon _bootstraTakeAwayWeapon;
    [SerializeField] private JoystickAttack _joystickAttack;

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
        _bootstrapWeapon.Initialize();
        GameplayMediator.Initialie();
    }

    public void RestartLevel() 
        => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void StopGame()
        => Time.timeScale = 0;
}
