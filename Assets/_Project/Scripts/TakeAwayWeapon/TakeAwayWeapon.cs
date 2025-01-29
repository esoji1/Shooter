using UnityEngine;
using UnityEngine.UI;

public class TakeAwayWeapon : MonoBehaviour
{
    private Button _take;
    private Button _awayWeapon;
    private Transform _weaponPosition;
    private Player _player;
    private JoystickAttack _joystickAttack;

    private BaseWeapon _weapon;
    private bool _isTake = false;
    private bool _isWeaponOccupied = false;

    public IAttackWeapon CurrentWeapon => _weapon;

    private void OnDestroy()
    {
        _take.onClick.RemoveListener(TakeWeapon);
        _awayWeapon.onClick.RemoveListener(AwayWeapon);
    }

    public void Initialize(Button take, Button awayWeapon, Transform weaponPosition,
        Player player, JoystickAttack joystickAttack)
    {
        _take = take;
        _awayWeapon = awayWeapon;
        _weaponPosition = weaponPosition;
        _player = player;
        _joystickAttack = joystickAttack;

        _take.onClick.AddListener(TakeWeapon);
        _awayWeapon.onClick.AddListener(AwayWeapon);
    }

    private void TakeWeapon()
    {
        if (_player.WeaponCollider == null)
            return;

        if (_isTake == false && _isWeaponOccupied == false)
        {
            _weapon = _player.WeaponCollider.GetComponentInChildren<BaseWeapon>();

            AssignWeaponPosition();
            ChangeSpriteRotation();

            _isTake = true;
            _isWeaponOccupied = true;
        }
    }

    private void AwayWeapon()
    {
        if (_isWeaponOccupied && _isTake)
            ResetParameters();
    }

    private void ResetParameters()
    {
        _weapon.transform.SetParent(null);
        _isWeaponOccupied = false;
        _isTake = false;
        _weapon = null;
        _joystickAttack.RotateWeapon.ChangeWeapom(null);
    }

    private void AssignWeaponPosition()
    {
        _weapon.transform.SetParent(_weaponPosition);
        _weapon.transform.position = _weaponPosition.transform.position;
    }

    private void ChangeSpriteRotation() => 
        _joystickAttack.RotateWeapon.ChangeWeapom(_weapon);
}

