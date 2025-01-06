using UnityEngine;

[CreateAssetMenu(menuName = "Config/ProjectileConfig/Projectile", fileName = "Projectile")]
public class ProjectileConfig : ScriptableObject
{
    [field: SerializeField] public GameObject Projectile;
    [field: SerializeField] public float Speed { get; private set; } = 10f;
    [field: SerializeField] public int Damage { get; private set; } = 5;
    [field: SerializeField] public float NumberSecondsBeforeRemoval { get; private set; } = 4f;
    [field: SerializeField] public float Delay { get; private set; } = 0.1f;
}
