using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class NormalAttack : IBaseAttack
    {
        private BaseWeapon _weapon;

        private Coroutine _shootCoroutine;

        public NormalAttack(BaseWeapon weapon) => _weapon = weapon;

        public BaseWeapon BaseWeapon => _weapon;

        public void Attack()
        {
            if (_weapon.RotateWeapon.IsAttackJoystickActive && _shootCoroutine == null)
                StartShooting();
            else if (_weapon.RotateWeapon.IsAttackJoystickActive == false && _shootCoroutine != null)
                StopShooting();
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(_weapon.WeaponConfig.Bullet.Delay);

                GameObject bulletGameObject = _weapon.SpawnProjectile.ProjectileSpawnPoint(_weapon.WeaponConfig.Bullet.Projectile, _weapon.Point);
                Projectile bullet = bulletGameObject.GetComponent<Projectile>();

                AudioSource audioSource = _weapon.PlayMusic.GetAvailableAudioSource(_weapon.AudioSources, _weapon.AudioSourcePrefab, _weapon.transform);
                audioSource.Play();

                bullet.GetComponent<Projectile>().Initialize(_weapon.Point.right, bullet, _weapon.CollisionEffect, _weapon.BloodEffect,
                    _weapon.WeaponConfig.Bullet, _weapon.Player.gameObject, (Collider2D collision) => false);
            }
        }

        private void StartShooting()
        {
            _weapon.WeaponView.StartRecoil();
            _weapon.WeaponView.StopIdle();

            _shootCoroutine = _weapon.StartCoroutine(Shoot());
        }

        private void StopShooting()
        {
            _weapon.WeaponView.StartIdle();
            _weapon.WeaponView.StopRecoil();

            _weapon.StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }
}