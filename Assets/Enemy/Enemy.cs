using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Enemy : MonoBehaviour
{
    [SerializeField] protected float CurrentHealth;

    protected float MinRandomHealth;
    protected float MaxRandomHealth;
    protected float MinHealth;
    protected Weapon Weapon;

    protected abstract void InitializeHealth();
}

public abstract partial class Enemy : IDamageable
{
    public abstract void TakeDamage(float damage);
    public abstract void Die();
}