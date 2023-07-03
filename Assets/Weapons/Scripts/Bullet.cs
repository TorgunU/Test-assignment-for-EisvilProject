using Assets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float SpeedShot;

    protected float Damage;
    protected Rigidbody2D _rigidbody2D;
    protected LayerMask IngoredLayer;

    public virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public abstract void IncreaseWeaponDamage(float weaponDamage);

    protected abstract void OnCollisionEnter2D(Collision2D collision);
    protected abstract void Fire();
}