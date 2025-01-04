using UnityEngine;

public class ActivateWeapon : MonoBehaviour
{
    [SerializeField] private TakeAwayWeapon _takeAwayWeapon;

    private void Update()
    {
        if (_takeAwayWeapon.CurrentWeapon == null)
            return;

        _takeAwayWeapon.CurrentWeapon.Attack();
    }
}
