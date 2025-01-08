using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon")]
public class WeaponConfig : ScriptableObject
{
    [field: SerializeField] public BaseWeapon WeaponPrefab { get; private set; }
    [field: SerializeField] public ProjectileConfig Bullet { get; private set; }
    [field: SerializeField] public AudioSource AudioPrefab { get; private set; }
}
