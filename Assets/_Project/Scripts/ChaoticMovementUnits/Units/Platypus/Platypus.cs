using UnityEngine;
using Random = UnityEngine.Random;

public class Platypus : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;

    private readonly int[] _rotation = { 90, -90, 30, -30 };
    private float _speed = 5f;
    private float _rayLength = 5f;

    private void Update()
    {
        HitWallChangedRotation();
        Move();
    }

    public void Initialize()
    {
        _direction = Vector2.right;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void HitWallChangedRotation()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, _direction, _rayLength);

        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out Wall wall))
        {
            transform.rotation *= Quaternion.Euler(0, 0, _rotation[Random.Range(0, _rotation.Length)]);
            _direction = transform.right;
        }
    }

    private void Move()
    {
        Vector2 currentPosition = transform.position;
        Vector2 deltaPosition = currentPosition - _direction;

        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.Self);
        FlipSpriteRenderer(deltaPosition);
    }

    private void FlipSpriteRenderer(Vector2 deltaPosition)
    {
        if (deltaPosition.x > 0)
            _spriteRenderer.flipX = true;
        else if (deltaPosition.x < 0)
            _spriteRenderer.flipX = false;
        else if (deltaPosition.y > 0)
            _spriteRenderer.flipX = true;
        else if (deltaPosition.y < 0)
            _spriteRenderer.flipX = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + _direction * _rayLength);
    }
}
