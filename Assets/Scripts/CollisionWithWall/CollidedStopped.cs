using UnityEngine;

public class CollidedStopped : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 1.2f;
    [SerializeField] private LayerMask _wallLayer;

    public bool IsThereWall { get; private set; } = true;

    public void CheckCollision(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _rayDistance, _wallLayer);

        if (hit.collider != null)
        {
            IsThereWall = hit.collider.TryGetComponent(out Wall wall);
        }
        else
        {
            IsThereWall = false;
        }
    }
}