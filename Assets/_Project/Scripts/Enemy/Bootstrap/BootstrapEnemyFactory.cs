using System.Collections.Generic;
using UnityEngine;

public class BootstrapEnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyConfig _skeletonConfig, _orcConfig, _magicianConfig;
    [SerializeField] private ProjectileConfig _fireballConfig;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private List<Transform> _point = new();
    [SerializeField] private Canvas _healthUi;
    [SerializeField] private HealthInfo _healthInfoPrefab;

    private EnemyFactory _enemyFactory;

    public EnemyFactory EnemyFactory => _enemyFactory;
    public List<Transform> Point => _point;

    public void Initialize()
    {
        _enemyFactory = new EnemyFactory(_skeletonConfig, _orcConfig, _magicianConfig,
            _fireballConfig, _player, _bloodEffect, _collisionEffect, _healthInfoPrefab, _healthUi);
    }
}