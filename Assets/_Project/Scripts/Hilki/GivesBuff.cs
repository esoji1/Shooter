using UnityEngine;

public abstract class GivesBuff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IBuffPicker buffPicker))
        {
            Affect(buffPicker);

            Destroy(gameObject);
        }
    }

    protected abstract void Affect(IBuffPicker buffPicker);
}
