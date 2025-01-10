using UnityEngine;

[CreateAssetMenu(menuName = "Config/LevelSettings/DifficultyConfig", fileName = "DifficultyConfig")]
public class DifficultyConfig : ScriptableObject
{
    [field: SerializeField] public EnemyConfig SkeletonConfig { get; private set; }
    [field: SerializeField] public EnemyConfig OrcConfig { get; private set; }
    [field: SerializeField] public EnemyConfig MagicianConfig { get; private set; }
    [field: SerializeField] public EnemyConfig MediumSkeletonConfig { get; private set; }
}
