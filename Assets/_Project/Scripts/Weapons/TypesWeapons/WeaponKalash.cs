using UnityEngine;

public class WeaponKalash : BaseWeapon
{
    public override void Initialize(RotateWeapon rotateWeapon, Bullet bullet, ParticleSystem collisionEffect,
        ParticleSystem bloodEffect, WeaponConfig weaponConfig, AudioSource audioSource)
    {
        base.Initialize(rotateWeapon, bullet, collisionEffect, bloodEffect, weaponConfig, audioSource);
    }
}