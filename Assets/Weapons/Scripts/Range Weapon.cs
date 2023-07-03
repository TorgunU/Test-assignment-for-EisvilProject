using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class RangeWeapon : Weapon
{
    [SerializeField] protected GameObject BulletPrefab;

    public override void Attack()
    {
        if (IsAttackCooldowned)
        {
            return;
        }

        Shoot();
        IsAttackCooldowned = true;

        StartCoroutine(CalculatingAttackDelay());
    }
}

public abstract partial class RangeWeapon : IShootable
{
    public abstract void Shoot();
}