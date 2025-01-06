using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoticMovementUnits : MonoBehaviour
{
    private Platypus _platypus;
    private List<Transform> _points = new();

    private int _maxSpawnedUnits = 25;

    public void Initialize(Platypus platypus, List<Transform> points)
    {
        _platypus = platypus;
        _points = points;
    }

    public void StartSpawnUnits()
        => StartCoroutine(MaxSpawnedUnits());

    private IEnumerator MaxSpawnedUnits()
    {
        int countUnits = 0;

        while (countUnits <= _maxSpawnedUnits)
        {
            Transform randomPoint = _points[Random.Range(0, _points.Count)];

            Platypus platypus = Instantiate(_platypus, randomPoint.position, Quaternion.identity, null);
            platypus.Initialize();

            countUnits++;

            yield return null;
        }
    }
}
