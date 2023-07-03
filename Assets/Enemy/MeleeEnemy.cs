using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private void Start()
    {
        Weapon = GetComponentInChildren<Weapon>();
        InitializeHealth();
    }

    public override void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= MinHealth)
        {
            Die();
        }
    }

    public override void Die()
    {
        //play effect/animation
        Destroy(gameObject);
    }

    protected override void InitializeHealth()
    {
        MinRandomHealth = 20;
        MaxRandomHealth = 150;
        CurrentHealth = Random.Range(MinRandomHealth, MaxRandomHealth);

        MinHealth = 0;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Weapon.Attack();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Weapon.Attack();
        }
    }
}