using UnityEngine;

public class MoveWhileAttacking : MonoBehaviour
{
    private BaseEnemy _enemy;

    private void Update()
    {
        if (_enemy.IsDie)
            return;

        Vector2 _direction = (_enemy.GetTarget.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, _enemy.GetTarget.position);

        Move(_direction, distance);
    }

    public void Initialize(BaseEnemy enemy)
    {
        _enemy = enemy;
            
        StartCoroutine(_enemy.ChangeEnemyPosition.SetRandomPosition(_enemy.GetConfig.AttackRadius));
    }

    private void Move(Vector2 _direction, float distance)
    {
        _enemy.Flip.FlipSpriteY(_direction, _enemy.GetBaseView.SpriteRenderer);

        if (IsDistancegreaterAttackRadius(distance))
        {
            _enemy.GetBaseView.StopAttack();
            _enemy.GetBaseView.StartWalk();

            Vector3 targetPosition = _enemy.GetTarget.position + _enemy.ChangeEnemyPosition.AddRandomPositionToGo;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _enemy.GetConfig.Speed * Time.deltaTime);
        }
    }

    private bool IsDistancegreaterAttackRadius(float distance) => distance > _enemy.GetConfig.AttackRadius;
}
