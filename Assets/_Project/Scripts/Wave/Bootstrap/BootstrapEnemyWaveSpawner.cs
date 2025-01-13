using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BootstrapEnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves = new List<Wave>();
    [SerializeField] private BootstrapEnemyFactory _bootstrapEnemy;
    [SerializeField] private float _timeBetweenWaves = 20f;
    [SerializeField] private TimerBetweenWavesView _timerBetweenWavesView;
    [SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
    [SerializeField] private TextMeshProUGUI _waveText;

    public EnemyWaveSpawner EnemyWaveSpawner => _enemyWaveSpawner;

    public void Initialize() 
        => _enemyWaveSpawner.Initialize(_waves, _bootstrapEnemy, _timeBetweenWaves, _timerBetweenWavesView, _waveText);
}
