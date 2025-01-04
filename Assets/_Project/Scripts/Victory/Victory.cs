using UnityEngine;

public class Victory
{
    private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    private GameObject _textVictory;
    private OpenMenuWithLevels _openMenuWithLevels;

    private float _delay = 5f;

    public Victory(BootstrapEnemyWaveSpawner bootstrapEnemyWaveSpawner, GameObject textVictory, OpenMenuWithLevels openMenuWithLevels)
    {
        _bootstrapEnemyWaveSpawner = bootstrapEnemyWaveSpawner;
        _textVictory = textVictory;
        _openMenuWithLevels = openMenuWithLevels;

        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.OnWin += Show;
        _openMenuWithLevels = openMenuWithLevels;
    }

    private void Show()
    {
        _textVictory.SetActive(true);

        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.OnWin -= Show;
        _openMenuWithLevels.GoMenuWithDelay(_delay);
    }
}
