using UnityEngine;

public class BootstrapGameplayMediator : MonoBehaviour
{
    [SerializeField] private DefeatPanel _defeatPanel;
    [SerializeField] private BootstrapLevel _bootstrapGameInitialize;

    private GameplayMediator _gameplayMediator;

    public void Initialie()
    {
        _gameplayMediator = new GameplayMediator(_defeatPanel, _bootstrapGameInitialize);

        _defeatPanel.Initialize(_gameplayMediator);
    }
}
