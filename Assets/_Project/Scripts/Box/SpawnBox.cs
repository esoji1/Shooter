using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBox : MonoBehaviour
{
    private GameObject _boxPrefab;
    private EnemyWaveSpawner _enemyWaveSpawner;
    private WeaponFactory _weaponFactory;
    private BootstraTakeAwayWeapon _takeAwayWeapon;
    private PointBox _pointBox;

    private PointWeapon _pointWeapon;

    private GameObject _box;
    private List<BaseWeapon> _weapon = new();

    private void OnDestroy() 
        => _enemyWaveSpawner.TimerBetweenWavesView.OnStartTimer -= SpawnBoxOnStartTimer;

    public void Initialize(GameObject boxPrefab, EnemyWaveSpawner enemyWaveSpawner, WeaponFactory weaponFactory, BootstraTakeAwayWeapon takeAwayWeapon,
        PointBox pointBox)
    {
        _boxPrefab = boxPrefab;
        _enemyWaveSpawner = enemyWaveSpawner;
        _weaponFactory = weaponFactory;
        _takeAwayWeapon = takeAwayWeapon;
        _pointBox = pointBox;

        _enemyWaveSpawner.TimerBetweenWavesView.OnStartTimer += SpawnBoxOnStartTimer;
    }

    public void FirtSpawnBox()
    {
        _box = Instantiate(_boxPrefab, _pointBox.transform);
        _pointWeapon = _box.GetComponentInChildren<PointWeapon>();

        StartCoroutine(PlayChestAnimation());
    }

    private void SpawnBoxOnStartTimer(float time)
    {
        _box = Instantiate(_boxPrefab, _pointBox.transform);
        _pointWeapon = _box.GetComponentInChildren<PointWeapon>();

        StartCoroutine(PlayChestAnimation());
    }

    private IEnumerator RemoveBox(float time)
    {
        yield return new WaitForSeconds(time);

        RemoveWeapon();
        Destroy(_box);
    }

    private IEnumerator PlayChestAnimation()
    {
        StartCoroutine(RemoveBox(_enemyWaveSpawner.TimeBetweenWaves));

        yield return new WaitForSeconds(1.5f);

        BaseWeapon weapon = _weaponFactory.Get(GetRandomEnumValue(), _pointWeapon.transform.position);
        _weapon.Add(weapon);
    }

    private WeaponTypes GetRandomEnumValue()
    {
        Array values = Enum.GetValues(typeof(WeaponTypes));
        int randomIndex = Random.Range(0, values.Length);

        return (WeaponTypes)values.GetValue(randomIndex);
    }

    private void RemoveWeapon()
    {
        foreach (BaseWeapon item in _weapon)
        {
            if (item.Equals(_takeAwayWeapon.TakeAwayWeapon.CurrentWeapon))
                continue;

            if (item != null)
                Destroy(item.gameObject);
        }
    }
}
