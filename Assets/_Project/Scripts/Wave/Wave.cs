using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemySpawner/Wave", fileName = "Wave")]
public class Wave : ScriptableObject
{
    [field: SerializeField] public List<EnemyGroup> EnemyGroups { get; private set; }
}
