using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemySpawner/EnemyGroup", fileName = "EnemyGroup")]
public class EnemyGroup : ScriptableObject
{
    [field: SerializeField] public EnemyTypes EnemyTypes { get; private set; }
    [field: SerializeField] public int Count { get; private set; }
    [field: SerializeField] public float SpawnInterval { get; private set; }
}