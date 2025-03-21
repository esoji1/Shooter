using System;
using UnityEngine;

public class WeaponFactory 
{
    private RotateWeapon _rotateWeapon;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private WeaponConfig _klashConfig, _emkaConfig, _gunConfig, _sniperConfig, _submachineConfig;
    private Player _player;
    private Aim _aim;

    public WeaponFactory(RotateWeapon rotateWeapon, ParticleSystem collisionEffect, 
        ParticleSystem bloodEffect, WeaponConfig klashConfig, WeaponConfig emkaConfig, WeaponConfig gunConfig,
        WeaponConfig sniperConfig, WeaponConfig submachineConfig, Player player, Aim aim)
    {
        _rotateWeapon = rotateWeapon;
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _klashConfig = klashConfig;
        _emkaConfig = emkaConfig;
        _gunConfig = gunConfig;
        _sniperConfig = sniperConfig;
        _submachineConfig = submachineConfig;
        _player = player;
        _aim = aim;
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

            case WeaponTypes.Gun:
                return _gunConfig;

            case WeaponTypes.Sniper:
                return _sniperConfig;

            case WeaponTypes.Submachine:
                return _submachineConfig;

            default:
                throw new ArgumentException(nameof(types));
        }
    }

    private BaseWeapon InitializeObject(BaseWeapon instance, WeaponConfig config)
    {
        switch (instance)
        {
            case WeaponKalash kalash:
                kalash.Initialize(_rotateWeapon, _collisionEffect, _bloodEffect, _klashConfig, _klashConfig.AudioPrefab,
                    _player, _aim);
                return kalash;

            case WeaponEmka emka:
                emka.Initialize(_rotateWeapon, _collisionEffect, _bloodEffect, _emkaConfig, _emkaConfig.AudioPrefab,
                    _player, _aim);
                return emka;

            case WeaponGun gun:
                gun.Initialize(_rotateWeapon, _collisionEffect, _bloodEffect, _gunConfig, _gunConfig.AudioPrefab,
                    _player, _aim);
                return gun;

            case WeaponSniper sniper:
                sniper.Initialize(_rotateWeapon, _collisionEffect, _bloodEffect, _sniperConfig, _sniperConfig.AudioPrefab,
                    _player, _aim);
                return sniper;

            case WeaponSubmachine submachine:
                submachine.Initialize(_rotateWeapon, _collisionEffect, _bloodEffect, _submachineConfig, _submachineConfig.AudioPrefab,
                    _player, _aim);
                return submachine;

            default:
                throw new ArgumentException(nameof(instance));
        }
    }
}
