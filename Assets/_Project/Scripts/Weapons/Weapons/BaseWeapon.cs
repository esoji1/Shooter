using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackWeaponFactory))]
public abstract class BaseWeapon : MonoBehaviour
{
    private RotateWeapon _rotateWeapon;
    private BaseWeaponView _weaponView;
    private ParticleSystem _collisionEffect;
    private ParticleSystem _bloodEffect;
    private WeaponConfig _weaponConfig;
    private AudioSource _audioSourcePrefab;
    private Player _player;

    private Transform _point;
    private Aim _aim;

    private List<AudioSource> _audioSources = new();

    private SpawnProjectile _spawnProjectile;
    private PlayMusic _playMusic;

    public Transform Point => _point;
    public BaseWeaponView WeaponView => _weaponView;
    public Aim Aim => _aim;
    public RotateWeapon RotateWeapon => _rotateWeapon;
    public WeaponConfig WeaponConfig => _weaponConfig;
    public Player Player => _player;
    public PlayMusic PlayMusic => _playMusic;
    public ParticleSystem CollisionEffect => _collisionEffect;
    public ParticleSystem BloodEffect => _bloodEffect;
    public SpawnProjectile SpawnProjectile => _spawnProjectile;
    public List<AudioSource> AudioSources => _audioSources;
    public AudioSource AudioSourcePrefab => _audioSourcePrefab;


    public virtual void Initialize(RotateWeapon rotateWeapon, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, WeaponConfig weaponConfig, AudioSource audioSource, Player player, Aim aim)
    {
        _player = player;
        _rotateWeapon = rotateWeapon;
        _aim = aim;

        _point = transform.GetComponentInChildren<PointWeapon>().transform;

        _weaponView = transform.GetComponentInChildren<BaseWeaponView>();
        _collisionEffect = collisionEffect;
        _bloodEffect = bloodEffect;
        _weaponConfig = weaponConfig;

        _weaponView.Initialize();
        _spawnProjectile = new SpawnProjectile();

        _audioSourcePrefab = audioSource;
        _playMusic = new PlayMusic();
    }
}
