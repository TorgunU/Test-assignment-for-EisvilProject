using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    [SerializeField] protected float AttackRange;

    public override void Attack()
    {
        if (IsAttackCooldowned)
        {
            return;
        }

        Hit();
        IsAttackCooldowned = true;

        StartCoroutine(CalculatingAttackDelay());
    }

    protected abstract void Hit();
}