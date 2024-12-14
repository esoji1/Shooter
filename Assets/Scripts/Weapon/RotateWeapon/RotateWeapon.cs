using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private WeaponKalash _weaponKalash;

    public bool IsAttackJoystickActive { get; private set; } = false;

    public void JoystickRotationWeapon(Vector2 inputVector, SpriteRenderer weaponView)
    {
        if (inputVector != Vector2.zero)
        {
            IsAttackJoystickActive = true;

            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
            FlipWeapon(inputVector, weaponView);

            _weaponTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            IsAttackJoystickActive = false;
        }
    }

    private void FlipWeapon(Vector2 inputVector, SpriteRenderer weaponView)
    {
        if (inputVector.x < 0f)
        {
            _weaponKalash.Point.localPosition = new Vector2(_weaponKalash.Point.localPosition.x, -0.02f);
            weaponView.flipY = true;
        }
        else if (inputVector.x > 0f)
        {
            _weaponKalash.Point.localPosition = new Vector2(_weaponKalash.Point.localPosition.x, 0.0203f);
            weaponView.flipY = false;
        }
    }
}