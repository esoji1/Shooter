using UnityEngine;

public class WeaponSubmachine : BaseWeapon
{
    public override void Initialize(RotateWeapon rotateWeapon, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, WeaponConfig weaponConfig, AudioSource audioSource, Player player)
    {
        base.Initialize(rotateWeapon, collisionEffect, bloodEffect, weaponConfig, audioSource, player);
    }
}
