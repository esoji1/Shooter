public class GameplayMediator
{
    private DefeatPanel _defeatPanel;
    private BootstrapLevel _bootstrapGameInitialize;

    public GameplayMediator(DefeatPanel defeatPanel, BootstrapLevel bootstrapGameInitialize)
    {
        _defeatPanel = defeatPanel;
        _bootstrapGameInitialize = bootstrapGameInitialize;

        _bootstrapGameInitialize.Player.Health.OnDie += OnDefeat;
    }

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _bootstrapGameInitialize.RestartLevel();
    }

    private void OnDefeat() => _defeatPanel.Show();
}
