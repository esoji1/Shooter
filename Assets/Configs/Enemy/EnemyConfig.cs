using UnityEngine;

[CreateAssetMenu(menuName = "EnemyConfig/EnemyConfig", fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; } = 1f;
    [field: SerializeField] public float AttackRadius { get; private set; } = 1f;
    [field: SerializeField] public int Damage { get; private set; } = 40;
}
