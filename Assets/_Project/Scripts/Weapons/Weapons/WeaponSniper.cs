using Assets.Scripts.Weapon;
using UnityEngine;

public class WeaponSniper : BaseWeapon, INormalAttack
{
    public override void Initialize(RotateWeapon rotateWeapon, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, WeaponConfig weaponConfig, AudioSource audioSource, Player player, Aim aim)
    {
        base.Initialize(rotateWeapon, collisionEffect, bloodEffect, weaponConfig, audioSource, player, aim);
    }
}
