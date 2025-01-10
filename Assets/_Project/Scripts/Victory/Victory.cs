using UnityEngine;

public class Victory
{
    private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    private GameObject _textVictory;
    private OpenMenuWithLevels _openMenuWithLevels;
    private BootstrapChaoticMovementUnits _bootstrapChaoticMovementUnits;

    private float _delay = 10;

    public Victory(BootstrapEnemyWaveSpawner bootstrapEnemyWaveSpawner, GameObject textVictory,
        OpenMenuWithLevels openMenuWithLevels, BootstrapChaoticMovementUnits bootstrapChaoticMovementUnits)
    {
        _bootstrapEnemyWaveSpawner = bootstrapEnemyWaveSpawner;
        _textVictory = textVictory;
        _openMenuWithLevels = openMenuWithLevels;

        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.OnWin += Show;

        _openMenuWithLevels = openMenuWithLevels;
        _bootstrapChaoticMovementUnits = bootstrapChaoticMovementUnits;
    }

    private void Show()
    {
        _textVictory.SetActive(true);

        _bootstrapEnemyWaveSpawner.EnemyWaveSpawner.OnWin -= Show;
        _bootstrapChaoticMovementUnits.ChaoticMovementUnits.StartSpawnUnits();

        _openMenuWithLevels.GoMenuWithDelay(_delay);
    }
}
