using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Weapon : MonoBehaviour
{
    protected LayerMask IngoredLayer;

    [SerializeField] protected Transform AttackPoint;
    [SerializeField] protected float AttackFrequencyInSeconds;

    protected bool IsAttackCooldowned;
    protected float Damage;

    public string Name { get; protected set; }

    private void Start()
    {
        IsAttackCooldowned = true;
        //IngoredLayer = gameObject.transform.parent.gameObject.layer;
    }
}

public abstract partial class Weapon : IAttackable
{
    public abstract void Attack();
    public abstract IEnumerator CalculatingAttackDelay();
}