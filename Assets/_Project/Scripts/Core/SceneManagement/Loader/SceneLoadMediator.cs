public class SceneLoadMediator
{
    private ILevelLoader _levelLoader;

    public SceneLoadMediator(ILevelLoader levelLoader) =>
        _levelLoader = levelLoader;

    public void GoToGameplayLevel(LevelLoadingData levelLoadingData) =>
        _levelLoader.Load(levelLoadingData);
}
