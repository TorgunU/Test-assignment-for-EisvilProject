using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _minHealth;

    private void Start()
    {
        _health = 100;
        _minHealth = 0;
    }
}

public partial class Player : IDamageable
{
    public void Die()
    {
        if(_health <= _minHealth)
        {
            //play effect/animation
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= _minHealth)
        {
            Die();
        }
    }
}