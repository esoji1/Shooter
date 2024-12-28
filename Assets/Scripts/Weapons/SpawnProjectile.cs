using UnityEngine;

public class SpawnProjectile
{
    public GameObject ProjectileSpawnPoint(GameObject projectile, Transform spawnPoint)
    {
        GameObject bullet = Object.Instantiate(projectile, spawnPoint.position, Quaternion.identity, null);

        Vector3 direction = spawnPoint.right;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        return bullet;
    }
}
