using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRandomWalkData")]
public class SimpleRandomWalkSO : ScriptableObject
{
    [field: SerializeField] public int Iterations { get; private set; } = 10;   
    [field: SerializeField] public int WalkLength { get; private set; } = 10;   
    [field: SerializeField] public bool StartRandomlyEachIteration { get; private set; } = true;   
}