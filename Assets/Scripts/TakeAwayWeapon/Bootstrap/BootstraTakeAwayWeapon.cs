using UnityEngine;
using UnityEngine.UI;

public class BootstraTakeAwayWeapon : MonoBehaviour
{
    [SerializeField] private Button _take;
    [SerializeField] private Button _awayWeapon;
    [SerializeField] private Transform _weaponPosition;
    [SerializeField] private Player _player;
    [SerializeField] private TakeAwayWeapon _takeAwayTheWeapon;
    [SerializeField] private JoystickAttack _joystickAttack;

    public void Initialize()
    {
        _takeAwayTheWeapon.Initialize(_take, _awayWeapon, _weaponPosition, _player, _joystickAttack);
    }
}
