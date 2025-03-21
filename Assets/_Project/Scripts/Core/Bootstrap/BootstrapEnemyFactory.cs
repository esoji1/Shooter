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
    [SerializeField] private Hilka _hilka;

    private EnemyFactory _enemyFactory;

    public EnemyFactory EnemyFactory => _enemyFactory;
    public List<Transform> Point => _point;

    public bool IsSpawn;
    public bool IsSpawn2;
    public bool IsSpawn3;
    public bool IsSpawn4;
    public bool IsSpawn5;

    public void Initialize(DifficultyConfig difficultyConfig)
        => _enemyFactory = new EnemyFactory(difficultyConfig, _fireballConfig, _player, _bloodEffect, _collisionEffect,
            _healthInfoPrefab, _healthUi, _takingDamage, _hilka);

    private void Update()
    {
        if (IsSpawn)
        {
            _enemyFactory.Get(EnemyTypes.Orc, transform.position);
            IsSpawn = false;
        }
        if (IsSpawn2)
        {
            _enemyFactory.Get(EnemyTypes.Skeleton, transform.position);
            IsSpawn2 = false;
        }
        if (IsSpawn3)
        {
            _enemyFactory.Get(EnemyTypes.MediumSkeleton, transform.position);
            IsSpawn3 = false;
        }
        if (IsSpawn4)
        {
            _enemyFactory.Get(EnemyTypes.Kamikaze, transform.position);
            IsSpawn4 = false;
        }
        if (IsSpawn5)
        {
            _enemyFactory.Get(EnemyTypes.Robot, transform.position);
            IsSpawn5 = false;
        }
    }
}