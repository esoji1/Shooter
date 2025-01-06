using UnityEngine;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton[] _levelSelectionButtons;

    private SceneLoadMediator _sceneLoader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoader)
        => _sceneLoader = sceneLoader;

    private void OnEnable()
    {
        foreach (var levelSelectionButton in _levelSelectionButtons)
            levelSelectionButton.Click += OnLevelSelected;
    }

    private void OnDisable()
    {
        foreach (var levelSelectionButton in _levelSelectionButtons)
            levelSelectionButton.Click -= OnLevelSelected;
    }

    private void OnLevelSelected(int level)
    {
        _sceneLoader.GoToGameplayLevel(new LevelLoadingData(level));
    }
}
