using UnityEngine;

public class Flip
{
    public void FlipSpriteY(Vector2 direction, SpriteRenderer spriteRenderer)
    {
        RotateDirections(direction, spriteRenderer);

        if (direction.x < 0f)
            spriteRenderer.flipY = true;
        else if (direction.x > 0f)
            spriteRenderer.flipY = false;
    }

    private void RotateDirections(Vector2 direction, SpriteRenderer spriteRenderer)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
