using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemyConfig/EnemyConfig", fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public BaseEnemy Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 1f;
    [field: SerializeField] public float AttackRadius { get; private set; } = 1f;
    [field: SerializeField] public int Damage { get; private set; } = 40;
    [field: SerializeField] public int Health { get; private set; } = 100;
    [field: SerializeField] public float RaycastAttack = 1f;
}
