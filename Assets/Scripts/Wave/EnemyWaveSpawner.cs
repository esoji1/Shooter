using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    private List<Wave> _waves;
    private BootstrapEnemyFactory _bootstrapEnemy;
    private float _timeBetweenWaves = 5f;
    private TimerBetweenWavesView _timerBetweenWavesView;

    private List<BaseEnemy> _activeEnemies = new();
    private int _currentWaveIndex = 0;
    private bool _isSpawning = false;

    public void Initialize(List<Wave> waves, BootstrapEnemyFactory bootstrapEnemy,
        float timeBetweenWaves, TimerBetweenWavesView timerBetweenWavesView)
    {
        _waves = waves;
        _bootstrapEnemy = bootstrapEnemy;
        _timeBetweenWaves = timeBetweenWaves;
        _timerBetweenWavesView = timerBetweenWavesView;
    }

    public void StartEnemyWaveSpawner()
        => StartCoroutine(SpawnWaves());

    private IEnumerator SpawnWaves()
    {
        while (_currentWaveIndex < _waves.Count)
        {
            if (!_isSpawning)
            {
                _isSpawning = true;

                if (_currentWaveIndex == 0)
                {
                    _timerBetweenWavesView.StartTimeBeetwenWaves(_timeBetweenWaves);

                    yield return new WaitForSeconds(_timeBetweenWaves);
                    yield return StartCoroutine(SpawnWave(_waves[_currentWaveIndex]));
                }

                if (_currentWaveIndex > 0)
                    yield return StartCoroutine(SpawnWave(_waves[_currentWaveIndex]));

                _isSpawning = false;

                yield return new WaitUntil(() => _activeEnemies.Count == 0);

                _currentWaveIndex++;

                if (_currentWaveIndex < _waves.Count)
                {
                    _timerBetweenWavesView.StartTimeBeetwenWaves(_timeBetweenWaves);
                    yield return new WaitForSeconds(_timeBetweenWaves);
                }
            }
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        foreach (EnemyGroup group in wave.EnemyGroups)
        {
            for (int i = 0; i < group.Count; i++)
            {
                BaseEnemy newEnemy = _bootstrapEnemy.EnemyFactory.Get(group.EnemyTypes,
                    _bootstrapEnemy.Point[Random.Range(0, _bootstrapEnemy.Point.Count)].position);

                _activeEnemies.Add(newEnemy);
                newEnemy.OnEnemyDie += HandleEnemyDeath;

                yield return new WaitForSeconds(group.SpawnInterval);
            }
        }
    }

    private void HandleEnemyDeath(BaseEnemy enemy)
    {
        if (_activeEnemies.Contains(enemy))
            _activeEnemies.Remove(enemy);
    }
}
