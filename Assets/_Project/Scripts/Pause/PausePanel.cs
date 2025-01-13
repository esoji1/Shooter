using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    private Button _pause;
    private Button _restart;
    private Button _exitHome;
    private GameObject _pausePanel;
    private PauseMediator _pauseMediator;

    private bool _isPause = true;

    private void OnDestroy()
    {
        _pause.onClick.RemoveListener(Pause);

        _restart.onClick.RemoveListener(OnRestartClick);
        _exitHome.onClick.RemoveListener(OnExitHomeClick);
    }

    public void Initialize(PauseMediator pauseMediator, Button pause, Button restart, Button exitHome, GameObject pausePanel)
    {
        _pause = pause;
        _restart = restart;
        _exitHome = exitHome;
        _pausePanel = pausePanel;
        _pauseMediator = pauseMediator;

        _pause.onClick.AddListener(Pause);
        _restart.onClick.AddListener(OnRestartClick);
        _exitHome.onClick.AddListener(OnExitHomeClick);
    }

    public void Show() => _pausePanel.SetActive(true);
    public void Hide() => _pausePanel.SetActive(false);

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
