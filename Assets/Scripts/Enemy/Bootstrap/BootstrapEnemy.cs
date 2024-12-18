using UnityEngine;

public class BootstrapEnemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig _skeletonConfig, _orcConfig, _magicianConfig;
    [SerializeField] private Player _player;
    [SerializeField] private Skeleton _skeleton;
    [SerializeField] private Orc _orc;
    [SerializeField] private Magician _magician;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private GameObject _fireball;

    private void Awake()
    {
        _skeleton.Initialize(_skeletonConfig, _player);
        _orc.Initialize(_orcConfig, _player);
        _magician.Initialize(_magicianConfig, _player, _bloodEffect, _fireball, _collisionEffect);
    }
}