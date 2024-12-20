using UnityEngine;

[CreateAssetMenu(menuName = "Config/ProjectileConfig/ProjectileConfig", fileName = "ProjectileConfig")]
public class ProjectileConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; } = 10f;
    [field: SerializeField] public int Damage { get; private set; } = 5;
    [field: SerializeField] public float NumberSecondsBeforeRemoval { get; private set; } = 4f;
}
