using UnityEngine;
using Zenject;

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
    [SerializeField] private BootstrapChaoticMovementUnits _bootstrapChaoticMovementUnits;

    private SceneLoadMediator _sceneLoader;
    private LevelLoadingData _levelLoadingData;
    private DifficultyConfig _difficultyConfig;

    public Player Player => _player;

    private void Awake()
    {
        Time.timeScale = 1;

        _joystickAttack.Initialize();

        _player.Initialize();
        _bootstrapEnemyFactory.Initialize(_difficultyConfig);

        _bootstrapEnemyWaveSpawner.Initialize();
        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.StartEnemyWaveSpawner();

        _bootstraTakeAwayWeapon.Initialize();
        _bootstrapWeaponFactory.Initialize();
        GameplayMediator.Initialie();

        _bootstrapSpawnBox.Initialize();
        _bootstrapSpawnBox.SpawnBox.FirtSpawnBox();

        _bootstrapVictory.Initialize();
        _bootstrapChaoticMovementUnits.Initialize();
    }

    [Inject]
    private void Construct(SceneLoadMediator sceneLoader, LevelLoadingData levelLoadingData)
    {
        _sceneLoader = sceneLoader;
        _levelLoadingData = levelLoadingData;
        _difficultyConfig = levelLoadingData.DifficultyConfig;
    }

    public void RestartLevel() 
        => _sceneLoader.GoToGameplayLevel(new LevelLoadingData(_levelLoadingData.Level));

    public void StopGame()
        => Time.timeScale = 0;
}
