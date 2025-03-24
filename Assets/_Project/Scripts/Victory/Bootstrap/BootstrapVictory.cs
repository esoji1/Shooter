using UnityEngine;

public class BootstrapVictory : MonoBehaviour
{
    [SerializeField] private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    [SerializeField] private GameObject _textVictory;
    [SerializeField] private OpenMenuWithLevels _openMenuWithLevels;
    [SerializeField] private BootstrapChaoticMovementUnits _bootstrapChaoticMovementUnits;

    private void Awake() =>
        new Victory(_bootstrapEnemyWaveSpawner, _textVictory, _openMenuWithLevels, _bootstrapChaoticMovementUnits);
}
