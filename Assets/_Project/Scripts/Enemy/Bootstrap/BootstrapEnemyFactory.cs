using System.Collections.Generic;
using UnityEngine;

public class BootstrapEnemyFactory : MonoBehaviour
{
    [SerializeField] private ProjectileConfig _fireballConfig;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private List<Transform> _point = new();
    [SerializeField] private Canvas _healthUi;
    [SerializeField] private HealthInfo _healthInfoPrefab;
    [SerializeField] private AudioSource _takingDamage;

    private EnemyFactory _enemyFactory;

    public EnemyFactory EnemyFactory => _enemyFactory;
    public List<Transform> Point => _point;

    public void Initialize(DifficultyConfig difficultyConfig) 
        => _enemyFactory = new EnemyFactory(difficultyConfig, _fireballConfig, _player, _bloodEffect,
            _collisionEffect, _healthInfoPrefab, _healthUi, _takingDamage);
}