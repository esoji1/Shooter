using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Weapon.Bullet
{
    public class DealDamage
    {
        public void Damage(Collider2D collision, int damage, GameObject bullet, ParticleSystem bloodEffect, GameObject owner,
            Func<Collider2D, bool> damageCondition)
        {
            if (collision.gameObject == owner || damageCondition.Invoke(collision))
                return;

            if (collision.TryGetComponent(out IDamage component))
            {
                ParticleSystem effect = Object.Instantiate(bloodEffect, bullet.transform.position, Quaternion.identity, null);
                effect.Play();

                component.Damage(damage);
                Object.Destroy(bullet);
            }
        }
    }
}
