using System.Collections;
using UnityEngine;

public class ChangeEnemyPosition
{
    private Vector3 _addRandomPositionToGo;

    public Vector3 AddRandomPositionToGo => _addRandomPositionToGo;

    public IEnumerator SetRandomPosition(float attackRadius)
    {
        float lessAttackRadius = attackRadius - 0.1f;
        float changePosition = 1.5f;

        while (true)
        {
            _addRandomPositionToGo = new Vector3(Random.Range(-lessAttackRadius, lessAttackRadius), Random.Range(-lessAttackRadius, lessAttackRadius));
            yield return new WaitForSeconds(changePosition);
        }
    }
}
