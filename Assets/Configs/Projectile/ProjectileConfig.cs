using System;
using UnityEngine;

[Serializable]
public class ProjectileConfig
{
    [field: SerializeField] public float Speed { get; private set; } = 10f;
    [field: SerializeField] public int Damage { get; private set; } = 5;
    [field: SerializeField] public float NumberSecondsBeforeRemoval { get; private set; } = 4f;
    [field: SerializeField] public float Delay { get; private set; } = 0.1f;
}
