using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exitHome;

    private GameplayMediator _gameplayMediator;

    private void OnEnable()
    {
        _restart.onClick.AddListener(OnRestartClick);
        _exitHome.onClick.AddListener(OnExitHomeClick);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(OnRestartClick);
        _exitHome.onClick.RemoveListener(OnExitHomeClick);
    }

    public void Initialize(GameplayMediator gameplayMediator) =>
        _gameplayMediator = gameplayMediator;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnRestartClick() =>
        _gameplayMediator.RestartLevel();

    private void OnExitHomeClick() =>
        SceneManager.LoadScene(0);
}
