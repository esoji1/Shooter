using UnityEngine;
using UnityEngine.UI;

public class BootstrapPausePanel : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private BootstrapLevel _bootstrapLevel;
    [SerializeField] private Button _pause;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exitHome;
    [SerializeField] private GameObject _pauseMenu;

    private PauseMediator _pauseMediator;

    public void Initialize()
    {
        _pauseMediator = new PauseMediator(_pausePanel, _bootstrapLevel);
        _pausePanel.Initialize(_pauseMediator, _pause, _restart, _exitHome, _pauseMenu);
    }
}
