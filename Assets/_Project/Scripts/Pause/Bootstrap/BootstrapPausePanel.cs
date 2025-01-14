using UnityEngine;

public class BootstrapPausePanel : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private BootstrapLevel _bootstrapLevel;

    private PauseMediator _pauseMediator;

    private void Awake()
    {
        _pauseMediator = new PauseMediator(_pausePanel, _bootstrapLevel);
        _pausePanel.Initialize(_pauseMediator);
    }
}
