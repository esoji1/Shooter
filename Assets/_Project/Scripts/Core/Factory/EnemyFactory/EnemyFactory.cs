using System;
using UnityEngine;

public class EnemyFactory
{
    private EnemyConfig _skeletonConfig, _orcConfig, _magicianConfig;
    private ProjectileConfig _fireballConfig;
    private Player _player;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;
    private HealthInfo _healthInfo;
    private Canvas _healthUi;

    public EnemyFactory(EnemyConfig skeletonConfig, EnemyConfig orcConfig, EnemyConfig magicianConfig,
        ProjectileConfig fireballConfig, Player player, ParticleSystem bloodEffect, ParticleSystem collisionEffect,
        HealthInfo healthInfo, Canvas healthUi)
    {
        _skeletonConfig = skeletonConfig;
        _orcConfig = orcConfig;
        _magicianConfig = magicianConfig;
        _fireballConfig = fireballConfig;
        _player = player;
        _bloodEffect = bloodEffect;
        _collisionEffect = collisionEffect;
        _healthInfo = healthInfo;
        _healthUi = healthUi;
    }

    public BaseEnemy Get(EnemyTypes enemyType, Vector3 position)
    {
        EnemyConfig config = GetConfigBy(enemyType);
        BaseEnemy instance = UnityEngine.Object.Instantiate(config.Prefab, position, Quaternion.identity, null);
        BaseEnemy baseEnemy = InitializeObject(instance, config);
        return baseEnemy;
    }

    private EnemyConfig GetConfigBy(EnemyTypes types)
    {
        switch (types)
        {
            case EnemyTypes.Skeleton:
                return _skeletonConfig;

            case EnemyTypes.Orc:
                return _orcConfig;

            case EnemyTypes.Magician:
                return _magicianConfig;

            default:
                throw new ArgumentException(nameof(types));
        }
    }

    private BaseEnemy InitializeObject(BaseEnemy instance, EnemyConfig config)
    {
        if (instance is Orc || instance is Skeleton)
        {
            instance.Initialize(config, _player, _healthInfo, _healthUi);

            return instance;
        }
        else if(instance is Magician)
        {
            Magician magician = instance.GetComponent<Magician>();
            magician.Initialize(config, _player, _bloodEffect,
                _collisionEffect, _fireballConfig, _healthInfo, _healthUi);

            return magician;
        }
        else
        {
            throw new ArgumentException(nameof(instance));
        }
    }
}
