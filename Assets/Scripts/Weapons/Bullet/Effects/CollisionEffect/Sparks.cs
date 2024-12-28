using UnityEngine;

public class Sparks : MonoBehaviour
{
    private float _lifetime = 0.5f;
    private float _respawnTime;

    private void Update()
    {
        _respawnTime += Time.deltaTime;

        if (_respawnTime > _lifetime)
        {
            Destroy(gameObject);
            _respawnTime = 0;
        }
    }
}
