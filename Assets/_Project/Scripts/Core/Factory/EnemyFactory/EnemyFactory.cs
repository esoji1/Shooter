using System;
using UnityEngine;

public class EnemyFactory
{
    private EnemyConfig _skeletonConfig, _orcConfig, _magicianConfig, _mediumSkeletonConfig, _kamikazeConfig, 
        _robotConfig;
    private ProjectileConfig _fireballConfig;
    private Player _player;
    private ParticleSystem _bloodEffect;
    private ParticleSystem _collisionEffect;
    private HealthInfo _healthInfo;
    private Canvas _healthUi;
    private AudioSource _takingDamage;
    private Hilka _hilka;

    public EnemyFactory(DifficultyConfig difficultyConfig, ProjectileConfig fireballConfig, Player player,
        ParticleSystem bloodEffect, ParticleSystem collisionEffect, HealthInfo healthInfo, Canvas healthUi,
        AudioSource takingDamage, Hilka hilka)
    {
        _skeletonConfig = difficultyConfig.SkeletonConfig;
        _orcConfig = difficultyConfig.OrcConfig;
        _magicianConfig = difficultyConfig.MagicianConfig;
        _mediumSkeletonConfig = difficultyConfig.MediumSkeletonConfig;
        _kamikazeConfig = difficultyConfig.KamikazeConfig;
        _robotConfig = difficultyConfig.RobotConfig;

        _fireballConfig = fireballConfig;
        _player = player;
        _bloodEffect = bloodEffect;
        _collisionEffect = collisionEffect;
        _healthInfo = healthInfo;
        _healthUi = healthUi;
        _takingDamage = takingDamage;
        _hilka = hilka;
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

            case EnemyTypes.MediumSkeleton:
                return _mediumSkeletonConfig;

            case EnemyTypes.Kamikaze:
                return _kamikazeConfig;

            case EnemyTypes.Robot:
                return _robotConfig;

            default:
                throw new ArgumentException(nameof(types));
        }
    }

    private BaseEnemy InitializeObject(BaseEnemy instance, EnemyConfig config)
    {
        if (instance is Orc || instance is Skeleton || instance is MediumSkeleton || instance is Kamikaze || 
            instance is Robot)
        {
            instance.Initialize(config, _player, _healthInfo, _healthUi, _takingDamage, _hilka);

            return instance;
        }
        else if (instance is Magician)
        {
            Magician magician = instance.GetComponent<Magician>();
            magician.Initialize(config, _player, _bloodEffect, _collisionEffect, _fireballConfig, _healthInfo,
                _healthUi, _takingDamage, _hilka);

            return magician;
        }
        else
        {
            throw new ArgumentException(nameof(instance));
        }
    }
}
