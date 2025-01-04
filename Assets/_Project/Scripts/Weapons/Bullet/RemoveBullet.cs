using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet
{
    public class RemoveBullet
    {
        private float _time;

        public void RemovalUponCollisionWall(Collider2D collision, GameObject bullet, ParticleSystem collisionEffect)
        {
            if (collision.TryGetComponent(out Wall wall))
            {
                if (bullet != null)
                {
                    ParticleSystem effect = Object.Instantiate(collisionEffect, bullet.transform.position, Quaternion.identity, null);
                    effect.Play();

                    Object.Destroy(bullet);
                }
            }
        }

        public void RemoveTimePasses(GameObject bullet, float numberSecondsBeforeRemoval)
        {
            _time += Time.deltaTime;

            if (_time >= numberSecondsBeforeRemoval)
            {
                if (bullet != null)
                    Object.Destroy(bullet);

                _time = 0f;
            }
        }
    }
}