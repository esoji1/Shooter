using UnityEngine;
using Zenject;

public class BootstrapLevel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BootstrapEnemyFactory _bootstrapEnemyFactory;
    [SerializeField] private BootstrapWeaponFactory _bootstrapWeaponFactory;
    [SerializeField] private BootstrapGameplayMediator _gameplayMediator;
    [SerializeField] private JoystickAttack _joystickAttack;

    private SceneLoadMediator _sceneLoader;
    private LevelLoadingData _levelLoadingData;
    private DifficultyConfig _difficultyConfig;

    private void Awake()
    {
        Time.timeScale = 1;

        _player.Initialize();
        _gameplayMediator.Initialize(_player);

        _bootstrapEnemyFactory.Initialize(_difficultyConfig);

        _joystickAttack.Initialize();
        _bootstrapWeaponFactory.Initialize(_joystickAttack);
    }

    [Inject]
    private void Construct(SceneLoadMediator sceneLoader, LevelLoadingData levelLoadingData)
    {
        _sceneLoader = sceneLoader;
        _levelLoadingData = levelLoadingData;
        _difficultyConfig = levelLoadingData.DifficultyConfig;
    }

    public void RestartLevel() =>
        _sceneLoader.GoToGameplayLevel(new LevelLoadingData(_levelLoadingData.Level));

    public void StopGame() =>
        Time.timeScale = 0;
}
