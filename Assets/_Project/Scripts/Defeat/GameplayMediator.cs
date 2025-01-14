public class GameplayMediator
{
    private DefeatPanel _defeatPanel;
    private BootstrapLevel _bootstrapLevel;

    public GameplayMediator(DefeatPanel defeatPanel, BootstrapLevel bootstrapGameInitialize, Player player)
    {
        _defeatPanel = defeatPanel;
        _bootstrapLevel = bootstrapGameInitialize;

        player.Health.OnDie += OnDefeat;
    }

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _bootstrapLevel.RestartLevel();
    }

    private void OnDefeat()
    {
        _bootstrapLevel.StopGame();
        _defeatPanel.Show();
    }
}
