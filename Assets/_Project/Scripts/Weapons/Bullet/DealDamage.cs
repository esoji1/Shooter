using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet
{
    public class DealDamage
    {
        public void Damage(Collider2D collision, int damage, GameObject bullet, ParticleSystem bloodEffect, GameObject owner)
        {
            if (collision.gameObject == owner || collision.TryGetComponent(out Magician _))
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
