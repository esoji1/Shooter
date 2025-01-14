using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exitHome;
    [SerializeField] private GameObject _pauseMenu;
    private PauseMediator _pauseMediator;

    private bool _isPause = true;

    private void OnEnable()
    {
        _pause.onClick.AddListener(Pause);
        _restart.onClick.AddListener(OnRestartClick);
        _exitHome.onClick.AddListener(OnExitHomeClick);
    }

    private void OnDisable()
    {
        _pause.onClick.RemoveListener(Pause);
        _restart.onClick.RemoveListener(OnRestartClick);
        _exitHome.onClick.RemoveListener(OnExitHomeClick);
    }

    public void Initialize(PauseMediator pauseMediator) 
        =>_pauseMediator = pauseMediator;  

    public void Show() => _pauseMenu.SetActive(true);
    public void Hide() => _pauseMenu.SetActive(false);

    private void Pause()
    {
        if (_isPause)
            StopGame();
        else
            StartGame();
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        _isPause = false;

        Show();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _isPause = true;

        Hide();
    }

    private void OnRestartClick()
       => _pauseMediator.RestartLevel();

    private void OnExitHomeClick()
        => SceneManager.LoadScene(0);
}
