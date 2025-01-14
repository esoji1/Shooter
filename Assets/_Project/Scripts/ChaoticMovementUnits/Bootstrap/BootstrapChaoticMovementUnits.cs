using System.Collections.Generic;
using UnityEngine;

public class BootstrapChaoticMovementUnits : MonoBehaviour
{
    [SerializeField] private Platypus _platypus;
    [SerializeField] private List<Transform> _point = new();
    [SerializeField] private ChaoticMovementUnits _chaoticMovementUnits;

    public ChaoticMovementUnits ChaoticMovementUnits => _chaoticMovementUnits;

    private void Awake() 
        => _chaoticMovementUnits.Initialize(_platypus, _point);
}
