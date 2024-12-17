using UnityEngine;

[CreateAssetMenu(menuName = "EnemyConfig/EnemyMeleeConfig", fileName = "EnemyMeleeConfig")]
public class EnemyMeleeConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; } = 1f;
    [field: SerializeField] public float AttackRadius { get; private set; } = 1f;
    [field: SerializeField] public int Damage { get; private set; } = 40;
}
