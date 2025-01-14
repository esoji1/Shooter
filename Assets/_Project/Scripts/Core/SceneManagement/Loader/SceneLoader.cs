public class SceneLoader : ILevelLoader
{
    private readonly ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader) 
        => _zenjectSceneLoader = zenjectSceneLoader;

    public void Load(LevelLoadingData levelLoadingData)
    {
        _zenjectSceneLoader.Load(container =>
        {
            container.BindInstance(levelLoadingData);
        }, 2);
    }
}
