using System;
using UnityEngine;

public class AttackFactory : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private BaseEnemy _enemy;

    private BaseAttack _attack;

    private void Start()
    {
        _enemy = GetComponent<BaseEnemy>();
        Initialize();
    }

    private void Update() => _attack.Update();

    private void Initialize()
    {
        switch (_enemy)
        {
            case NormalAttack normalAttack:
                _attack = new MeleeNormalAttack(_enemy, _layer);
                break;

            case HealingAttack healingAttack:
                _attack = new MeleeHealingAttack(_enemy, _layer);
                break;

            case OneShotAttack oneShotAttack:
                _attack = new MeleeOneShotAttack(_enemy);
                break;

            case RangeAttack rangeAttack:
                _attack = new RangedAttack(_enemy);
                break;

            default:
                throw new ArgumentException($"There is no such type of attack {nameof(_enemy)}");
        }
    }
}
