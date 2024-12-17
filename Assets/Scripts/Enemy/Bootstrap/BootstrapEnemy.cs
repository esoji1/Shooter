using UnityEngine;

public class BootstrapEnemy : MonoBehaviour
{
    [SerializeField] private EnemyMeleeConfig _skeletonConfig, _orcConfig;
    [SerializeField] private Player _player;
    [SerializeField] private Skeleton _skeleton;
    [SerializeField] private Orc _orc;

    private void Awake()
    {
        _skeleton.Initialize(_skeletonConfig, _player);
        _orc.Initialize(_orcConfig, _player);
    }
}