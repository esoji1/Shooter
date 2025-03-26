using Assets.Scripts.Weapon;
using System;
using UnityEngine;

public class AttackWeaponFactory : MonoBehaviour
{
    private BaseWeapon _weapon;
    private IBaseAttack _baseAttack;

    public IBaseAttack BaseAttack => _baseAttack;

    private void Start()
    {
        _weapon = GetComponent<BaseWeapon>();
        Get();
    }

    private void Get()
    {
        switch(_weapon)
        {
            case INormalAttack:
                _baseAttack = new NormalAttack(_weapon);
                break;

            default:
                throw new ArgumentException($"there is no such type {_weapon} of attack");
        }
    }
}
