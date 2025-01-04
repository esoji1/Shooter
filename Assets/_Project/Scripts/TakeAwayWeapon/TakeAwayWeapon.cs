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
    private Collider2D _collider;
    private bool _isTake = false;
    private bool _isWeaponOccupied = false;

    public IAttackWeapon CurrentWeapon => _weapon;

    private void OnDestroy()
    {
        _take.onClick.RemoveListener(TakeWeapon);
        _awayWeapon.onClick.RemoveListener(AwayWeapon);

        _player.OnEnterCollider -= EnterTake;
        _player.OnExitCollider -= ExitTake;
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

        _player.OnEnterCollider += EnterTake;
        _player.OnExitCollider += ExitTake;
    }

    private void TakeWeapon()
    {
        if (_collider != null && _isWeaponOccupied == false)
        {
            if (_isTake)
            {
                AssignWeaponPosition();

                ChangeSpriteRotation();

                _isWeaponOccupied = true;
                Debug.Log("Взял");
            }
        }
    }

    private void AwayWeapon()
    {
        if (_isWeaponOccupied && _collider != null)
        {
            ResetParameters();
            Debug.Log("Бросил");
        }
    }

    private void EnterTake(Collider2D collider)
    {
        _isTake = true;

        if (_collider == null || _isWeaponOccupied == false)
            _collider = collider;
    }

    private void ExitTake(Collider2D collider)
        => _isTake = false;

    private void ResetParameters()
    {
        _collider.transform.SetParent(null);
        _isWeaponOccupied = false;
        _collider = null;
        _weapon = null;
        _joystickAttack.RotateWeapon.ChangeWeapom(null);
    }

    private void AssignWeaponPosition()
    {
        _collider.transform.SetParent(_weaponPosition);
        _collider.transform.position = _weaponPosition.transform.position;
    }

    private void ChangeSpriteRotation()
    {
        _weapon = _collider.GetComponentInChildren<BaseWeapon>();
        _joystickAttack.RotateWeapon.ChangeWeapom(_weapon);
    }
}

