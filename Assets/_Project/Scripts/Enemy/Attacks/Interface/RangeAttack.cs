using UnityEngine;

public interface RangeAttack
{
    ProjectileConfig FireballConfig { get; }
    ParticleSystem BloodEffect { get; }
    ParticleSystem CollisionEffect { get; }
    PointAttack GetPointAttack { get; }
    SpawnProjectile SpawnProjectile { get; }
    GameObject GameObject { get; }
}
