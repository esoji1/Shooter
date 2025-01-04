using System;
using UnityEngine;

public class WeaponFactory 
{
    private RotateWeapon _rotateWeapon;
    private Bullet _bullet;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private WeaponConfig _klashConfig, _emkaConfig;
    private AudioSource _audioSourcePrefab;

    public WeaponFactory(RotateWeapon rotateWeapon, Bullet bullet, ParticleSystem collisionEffect, 
        ParticleSystem bloodEffect, WeaponConfig klashConfig,WeaponConfig emkaConfig, 
        AudioSource audioSourcePrefab)
    {
        _rotateWeapon = rotateWeapon;
        _bullet = bullet;
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _klashConfig = klashConfig;
        _emkaConfig = emkaConfig;
        _audioSourcePrefab = audioSourcePrefab;
    }

    public BaseWeapon Get(WeaponTypes weaponType, Vector3 position)
    {
        WeaponConfig config = GetConfigBy(weaponType);
        BaseWeapon instance = UnityEngine.Object.Instantiate(config.WeaponPrefab, position, Quaternion.identity, null);
        BaseWeapon baseEnemy = InitializeObject(instance, config);
        return baseEnemy;
    }

    private WeaponConfig GetConfigBy(WeaponTypes types)
    {
        switch (types)
        {
            case WeaponTypes.Emka:
                return _emkaConfig;

            case WeaponTypes.Kalash:
                return _klashConfig;

            default:
                throw new ArgumentException(nameof(types));
        }
    }

    private BaseWeapon InitializeObject(BaseWeapon instance, WeaponConfig config)
    {
        switch (instance)
        {
            case WeaponKalash kalash:
                kalash.Initialize(_rotateWeapon, _bullet, _collisionEffect, _bloodEffect, _klashConfig, _audioSourcePrefab);
                return kalash;

            case WeaponEmka emka:
                emka.Initialize(_rotateWeapon, _bullet, _collisionEffect, _bloodEffect, _emkaConfig, _audioSourcePrefab);
                return emka;

            default:
                throw new ArgumentException(nameof(instance));
        }
    }
}
