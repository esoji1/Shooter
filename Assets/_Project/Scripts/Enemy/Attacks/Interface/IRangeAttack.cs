using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IRangeAttack
    {
        ProjectileConfig FireballConfig { get; }
        ParticleSystem BloodEffect { get; }
        ParticleSystem CollisionEffect { get; }
        PointAttack GetPointAttack { get; }
        SpawnProjectile SpawnProjectile { get; }
        GameObject GameObject { get; }
    }
}