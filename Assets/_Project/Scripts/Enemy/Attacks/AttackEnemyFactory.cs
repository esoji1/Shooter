using Assets.Scripts.Enemy;
using System;
using UnityEngine;

public class AttackEnemyFactory : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private BaseEnemy _enemy;

    private IBaseAttack _attack;

    private void Start()
    {
        _enemy = GetComponent<BaseEnemy>();
        Get();
    }

    private void Update() => _attack.Update();

    private void Get()
    {
        switch (_enemy)
        {
            case INormalAttack normalAttack:
                _attack = new MeleeNormalAttack(_enemy, _layer);
                break;

            case IHealingAttack healingAttack:
                _attack = new MeleeHealingAttack(_enemy, _layer);
                break;

            case IOneShotAttack oneShotAttack:
                _attack = new MeleeOneShotAttack(_enemy);
                break;

            case IRangeAttack rangeAttack:
                _attack = new RangedAttack(_enemy);
                break;

            default:
                throw new ArgumentException($"There is no such type of attack {nameof(_enemy)}");
        }
    }
}
