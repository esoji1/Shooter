using UnityEngine;

public class RotateWeapon
{
    private BaseWeapon _weapon;
    private Transform _weaponTransform;

    public bool IsAttackJoystickActive { get; private set; } = false;

    public RotateWeapon(WeaponPosition weaponTransform)
    {
        _weaponTransform = weaponTransform.transform;
    }

    public void JoystickRotationWeapon(Vector2 inputVector)
    {
        if (inputVector != Vector2.zero)
        {
            IsAttackJoystickActive = true;

            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
            FlipWeaponPointShooting(inputVector);

            _weaponTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            IsAttackJoystickActive = false;
            ResetWeaponRotation();
        }
    }

    public void ChangeWeapom(BaseWeapon weapon) 
        => _weapon = weapon;

    private void FlipWeaponPointShooting(Vector2 inputVector)
    {
        if (_weapon == null)
            return;

        float heightYLessZero = -0.02f;
        float heightYGreaterZero = 0.0203f;

        if (inputVector.x < 0f)
        {
            _weapon.Point.localPosition = new Vector2(_weapon.Point.localPosition.x, heightYLessZero);
            _weapon.WeaponView.SpriteRenderer.flipY = true;
        }
        else if (inputVector.x > 0f)
        {
            _weapon.Point.localPosition = new Vector2(_weapon.Point.localPosition.x, heightYGreaterZero);
            _weapon.WeaponView.SpriteRenderer.flipY = false;
        }
    }

    private void ResetWeaponRotation()
    {
        _weaponTransform.rotation = Quaternion.identity; 
        FlipWeaponPointShooting(Vector2.right);
    }
}