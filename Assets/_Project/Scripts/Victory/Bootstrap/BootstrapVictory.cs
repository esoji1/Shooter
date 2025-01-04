using UnityEngine;

public class BootstrapVictory : MonoBehaviour
{
    [SerializeField] private BootstrapEnemyWaveSpawner _bootstrapEnemyWaveSpawner;
    [SerializeField] private GameObject _textVictory;
    [SerializeField] private OpenMenuWithLevels _openMenuWithLevels;

    private Victory _victory;

    public void Initialize()
    {
        _victory = new Victory(_bootstrapEnemyWaveSpawner, _textVictory, _openMenuWithLevels);
    }
}
