public class PauseMediator
{
    private PausePanel _pausePanel;
    private BootstrapLevel _bootstrapLevel;

    public PauseMediator(PausePanel pausePanel, BootstrapLevel bootstrapLevel)
    {
        _pausePanel = pausePanel;
        _bootstrapLevel = bootstrapLevel;
    }

    public void RestartLevel()
    {
        _pausePanel.Hide();
        _bootstrapLevel.RestartLevel();
    }
}
