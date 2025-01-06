using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CollidedStopped _collidedStopped;

    public void MovePlayer(Vector2 directin)
    {
        _collidedStopped.CheckCollision(directin);

        if (_collidedStopped.IsThereWall == false)
        {
            Vector2 movement = directin.normalized * _speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}