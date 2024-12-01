using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    public void MovePlayer(Vector2 directin)
    {
        directin = directin.normalized * _speed;
        transform.Translate(directin *  Time.deltaTime);
    }
}